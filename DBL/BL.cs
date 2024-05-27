using DBL.Entities;
using DBL.Enums;
using DBL.Helpers;
using DBL.Models;
using DBL.Models.Dashboard;
using DBL.Models.Reports;
using DBL.Models.Reports.ShiftSummary;
using DBL.UOW;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Text;

namespace DBL
{
    public class BL
    {
        private UnitOfWork db;
        private string _connString;
        static bool mailSent = false;
        Encryptdecrypt sec = new Encryptdecrypt();
        Stringgenerator str = new Stringgenerator();
        EmailSenderHelper emlsnd = new EmailSenderHelper();
        public BL(string connString)
        {
            this._connString = connString;
            db = new UnitOfWork(connString);
        }
        #region Verify and Validate System Staff
        public Task<UsermodelResponce> ValidateSystemStaff(string userName, string password)
        {
            return Task.Run(async () =>
            {
                UsermodelResponce userModel = new UsermodelResponce { };
                var resp = db.SecurityRepository.VerifySystemStaff(userName);
                if (resp.RespStatus == 0)
                {
                    Encryptdecrypt sec = new Encryptdecrypt();
                    string descpass = sec.Decrypt(resp.Usermodel.Passwords, resp.Usermodel.Passharsh);
                    if (password == descpass)
                    {
                        //get staff Stations Data
                        var stations = db.SecurityRepository.GetSystemStaffStation(resp.Usermodel.Userid);
                        userModel = new UsermodelResponce
                        {
                            RespStatus = resp.RespStatus,
                            RespMessage = resp.RespMessage,
                            Token = "",
                            Usermodel = new UsermodeldataResponce
                            {
                                Userid = resp.Usermodel.Userid,
                                Tenantid = resp.Usermodel.Tenantid,
                                Tenantname = resp.Usermodel.Tenantname,
                                Tenantsubdomain = resp.Usermodel.Tenantsubdomain,
                                TenantLogo = resp.Usermodel.TenantLogo,
                                Currencyname = resp.Usermodel.Currencyname,
                                Utcname = resp.Usermodel.Utcname,
                                Firstname = resp.Usermodel.Firstname,
                                Fullname = resp.Usermodel.Fullname,
                                Phonenumber = resp.Usermodel.Phonenumber,
                                Username = resp.Usermodel.Username,
                                Emailaddress = resp.Usermodel.Emailaddress,
                                Roleid = resp.Usermodel.Roleid,
                                Rolename = resp.Usermodel.Rolename,
                                Passharsh = resp.Usermodel.Passharsh,
                                Passwords = resp.Usermodel.Passwords,
                                LimitTypeId = resp.Usermodel.LimitTypeId,
                                LimitTypeValue = resp.Usermodel.LimitTypeValue,
                                Isactive = resp.Usermodel.Isactive,
                                Isdeleted = resp.Usermodel.Isdeleted,
                                //Loginstatus = Enum.GetName(typeof(UserLoginStatus), Convert.ToInt32(resp.Usermodel.Loginstatus)),
                                Loginstatus = resp.Usermodel.Loginstatus,
                                Passwordresetdate = resp.Usermodel.Passwordresetdate,
                                Createdby = resp.Usermodel.Createdby,
                                Modifiedby = resp.Usermodel.Modifiedby,
                                Lastlogin = resp.Usermodel.Lastlogin,
                                Datemodified = resp.Usermodel.Datemodified,
                                Datecreated = resp.Usermodel.Datecreated,
                                Permission = resp.Usermodel.Permission,
                                Stations = stations,
                            }
                        };
                        return userModel;
                    }
                    else
                    {
                        userModel.RespStatus = 1;
                        userModel.RespMessage = "Incorrect Username or Password";
                    }
                }
                else
                {
                    userModel.RespStatus = 1;
                    userModel.RespMessage = resp.RespMessage;
                }
                return userModel;
            });
        }

        public Task<Genericmodel> Resendstaffpassword(Emailsendingdata Obj)
        {
            return Task.Run(() =>
            {
                Genericmodel model = new Genericmodel();
                var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Forgotpasswords");
                if (commtempdata != null)
                {
                    StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                    StrBodyEmail.Replace("@CompanyLogo", commtempdata.Modulelogo);
                    StrBodyEmail.Replace("@CompanyName", commtempdata.Module);
                    StrBodyEmail.Replace("@CompanyEmail", commtempdata.Moduleemail);
                    StrBodyEmail.Replace("@Fullname", Obj.Fullname);
                    StrBodyEmail.Replace("@Username", Obj.Username);
                    StrBodyEmail.Replace("@Password", sec.Decrypt(Obj.Password, Obj.Passharsh));
                    StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                    string message = StrBodyEmail.ToString();
                    //log Email Messages
                    EmailLogs Logs = new EmailLogs
                    {
                        EmailLogId = 0,
                        TenantId = Obj.TenantId,
                        EmailAddress = Obj.Emailaddress,
                        EmailSubject = commtempdata.Templatesubject,
                        EmailMessage = message,
                        IsEmailSent = false,
                        DateTimeSent = DateTime.Now,
                        Datecreated = DateTime.Now,
                    };
                    var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                    bool data = emlsnd.UttambsolutionssendemailAsync(Obj.Emailaddress, commtempdata.Templatesubject, message, true,"","","");
                    if (data)
                    {
                        model.RespStatus = 0;
                        model.RespMessage = "Email Sent";
                    }
                    else
                    {
                        model.RespStatus = 1;
                        model.RespMessage = "Email not Sent";
                    }
                }
                else
                {
                    model.RespStatus = 1;
                    model.RespMessage = "Template not found!";
                }
                return model;
            });
        }

        public Task<UsermodelResponce> Forgotuserpasswordpost(StaffForgotPassword obj)
        {
            return Task.Run(async () =>
            {

                UsermodelResponce userModel = new UsermodelResponce { };
                userModel = db.SecurityRepository.VerifySystemStaff(obj.EmailAddress);
                return userModel;
            });
        }

        #endregion

        #region Verify and Validate System Customer User
        public Task<CustomermodelResponce> ValidateSystemCustomer(string userName, string password)
        {
            return Task.Run(async () =>
            {
                CustomermodelResponce customerModel = new CustomermodelResponce { };
                var resp = db.CustomerRepository.VerifySystemCustomer(userName);
                if (resp.RespStatus == 0)
                {
                    Encryptdecrypt sec = new Encryptdecrypt();
                    string descpass = sec.Decrypt(resp.CustomerModel.Pin, resp.CustomerModel.Pinharsh);
                    if (password == descpass)
                    {
                        customerModel = new CustomermodelResponce
                        {
                            RespStatus = resp.RespStatus,
                            RespMessage = resp.RespMessage,
                            Token = "",
                            CustomerModel = new CustomermodeldataResponce
                            {
                                CustomerId = resp.CustomerModel.CustomerId,
                                Tenantid = resp.CustomerModel.Tenantid,
                                Firstname = resp.CustomerModel.Firstname,
                                Lastname = resp.CustomerModel.Lastname,
                                Companyname = resp.CustomerModel.Companyname,
                                Emailaddress = resp.CustomerModel.Emailaddress,
                                Phoneid = resp.CustomerModel.Phoneid,
                                Phonenumber = resp.CustomerModel.Phonenumber,
                                Dob = resp.CustomerModel.Dob,
                                Gender = resp.CustomerModel.Gender,
                                IDNumber = resp.CustomerModel.IDNumber,
                                Designation = resp.CustomerModel.Designation,
                                Pin = resp.CustomerModel.Pin,
                                Pinharsh = resp.CustomerModel.Pinharsh,
                                CompanyAddress = resp.CustomerModel.CompanyAddress,
                                ReferenceNumber = resp.CustomerModel.ReferenceNumber,
                                CompanyIncorporationDate = resp.CustomerModel.CompanyIncorporationDate,
                                CompanyRegistrationNo = resp.CustomerModel.CompanyRegistrationNo,
                                CompanyPIN = resp.CustomerModel.CompanyPIN,
                                CompanyVAT = resp.CustomerModel.CompanyVAT,
                                Contractstartdate = resp.CustomerModel.Contractstartdate,
                                Contractenddate = resp.CustomerModel.Contractenddate,
                                StationId = resp.CustomerModel.StationId,
                                CountryId = resp.CustomerModel.CountryId,
                                NoOfTransactionPerDay = resp.CustomerModel.NoOfTransactionPerDay,
                                AmountPerDay = resp.CustomerModel.AmountPerDay,
                                ConsecutiveTransTimeMin = resp.CustomerModel.ConsecutiveTransTimeMin,
                                IsPortaluser = resp.CustomerModel.IsPortaluser,
                                IsActive = resp.CustomerModel.IsActive,
                                IsDeleted = resp.CustomerModel.IsDeleted,
                                Createdby = resp.CustomerModel.Createdby,
                                Modifiedby = resp.CustomerModel.Modifiedby,
                                Datecreated = resp.CustomerModel.Datecreated,
                                Datemodified = resp.CustomerModel.Datemodified,
                            }
                        };
                        return customerModel;
                    }
                    else
                    {
                        customerModel.RespStatus = 1;
                        customerModel.RespMessage = "Incorrect Username or Password";
                    }
                }
                else
                {
                    customerModel.RespStatus = 1;
                    customerModel.RespMessage = resp.RespMessage;
                }
                return customerModel;
            });
        }

        #endregion

        #region System Dashboard
        public Task<SystemDashboardData> Getsystemdashboarddata(long TenantId,long StationId, DateTime TodayDate)
        {
            return Task.Run(() =>
            {
                var Resp = db.DashboardRepository.Getsystemdashboarddata(TenantId, StationId, TodayDate);
                return Resp;
            });
        }
        #endregion

        #region system Suppliers
        public Task<IEnumerable<SupplierDetailData>> Getsystemsupplierslistdata(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Getsystemsupplierslistdata(TenantId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemsuppliersdata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Registersystemsuppliersdata(obj);
                return Resp;
            });
        }
        public Task<SystemSupplier> Getsystemsupplierdetailbyid(long SupplierId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Getsystemsupplierdetailbyid(SupplierId);
                return Resp;
            });
        }
        #endregion

        #region Verify System Gadget Staff
        public Task<SystemStaffData> VerifySystemStaff(long StationId, string? Username, string? Pin)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.VerifySystemStaff(StationId, Username);
                return Resp;
            });
        }
        #endregion

        #region System Gadget SetUp
        public Task<SystemGadgetResponseModel> SystemGadgetsAppSetUp(string SerialNumber)
        {
            return Task.Run(() =>
            {
                var Resp = db.SetupRepository.SystemGadgetsAppSetUp(SerialNumber);
                return Resp;
            });
        }
        #endregion

        #region System Permissions
        public Task<IEnumerable<Systempermissions>> Getsystempermissiondata()
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Getsystempermissiondata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystempermissiondata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Registersystempermissiondata(obj);
                return Resp;
            });
        }
        public Task<Systempermissions> Getsystempermissiondatabyid(long Permissionid)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Getsystempermissiondatabyid(Permissionid);
                return Resp;
            });
        }
        #endregion

        #region Tenant Settings
        public Task<IEnumerable<SystemTenantAccountData>> Getsystemtenantaccountdata()
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Getsystemtenantaccountdata();
                return Resp;
            });
        }
        public Task<SystemTenantAccount> Getsystemtenantaccountbytenantid(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Getsystemtenantaccountbytenantid(TenantId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registertenantaccountdata(SystemTenantAccount obj)
        {
            return Task.Run(() =>
            {
                string Passwordhash = str.RandomString(12);
                string Password = str.RandomString(8).ToString();
                obj.Passwords = sec.Encrypt(Password, Passwordhash);
                obj.TenantReference = str.RandomString(10);
                obj.Passharsh = Passwordhash;
                var Resp = db.SettingsRepository.Registertenantaccountdata(JsonConvert.SerializeObject(obj));
                var RespData = db.SecurityRepository.Resendsystemstaffpassword(Convert.ToInt64(Resp.Data1));
                if (RespData.Userid >= 1)
                {
                    //send Card Assignment Email
                    var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Tenantonboaringtemplate");
                    if (commtempdata != null)
                    {
                        StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                        StrBodyEmail.Replace("@CompanyLogo", RespData.TenantLogo);
                        StrBodyEmail.Replace("@CompanyName", RespData.Tenantname);
                        StrBodyEmail.Replace("@CompanyEmail", RespData.TenantEmail);
                        StrBodyEmail.Replace("@Fullname", RespData.Firstname + " " + RespData.Lastname);
                        StrBodyEmail.Replace("@Username", RespData.Username);
                        StrBodyEmail.Replace("@Password", sec.Decrypt(RespData.Passwords, RespData.Passharsh));
                        StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                        string message = StrBodyEmail.ToString();
                        //log Email Messages
                        EmailLogs Logs = new EmailLogs
                        {
                            EmailLogId = 0,
                            TenantId = RespData.Tenantid,
                            EmailAddress = RespData.Emailaddress,
                            EmailSubject = commtempdata.Templatesubject,
                            EmailMessage = message,
                            IsEmailSent = false,
                            DateTimeSent = DateTime.Now,
                            Datecreated = DateTime.Now,
                        };
                        var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                        bool data = emlsnd.UttambsolutionssendemailAsync(RespData.Emailaddress, commtempdata.Templatesubject, message, true, RespData.EmailServer, RespData.EmailServerEmail, RespData.EmailPassword);
                        if (data)
                        {
                            Resp.RespStatus = 0;
                            Resp.RespMessage = "Email Sent";
                        }
                        else
                        {
                            Resp.RespStatus = 1;
                            Resp.RespMessage = "Email not Sent";
                        }
                    }
                    else
                    {
                        Resp.RespStatus = 1;
                        Resp.RespMessage = "Template not found!";
                    }
                }
                else
                {
                    Resp.RespStatus = 1;
                    Resp.RespMessage = "Staff not found!";
                }
                return Resp;
            });
        }
        #endregion

        #region Loyalty Settings
        public Task<IEnumerable<LoyaltySettingsModelData>> Getsystemloyaltysettingsdata()
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Getsystemloyaltysettingsdata();
                return Resp;
            });
        }
        public Task<SystemLoyaltySetings> GetSystemLoyaltySettingsById(long LoyaltysettId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.GetSystemLoyaltySettingsById(LoyaltysettId);
                return Resp;
            });
        }
        public Task<SystemLoyaltySetings> GetSystemLoyaltySettings(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.GetSystemLoyaltySettings(TenantId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterLoyaltySettings(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.RegisterLoyaltySettings(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Staff Role
        public Task<IEnumerable<SystemUserRoles>> GetSystemRoles(long TenantId, int Offset, int Count)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.GetSystemRoles(TenantId, Offset, Count);
                return Resp;
            });
        }

        public Task<Genericmodel> RegisterSystemStaffRole(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.RegisterSystemStaffRole(JsonObj);
                return Resp;
            });
        }
        public Task<SystemUserRoles> GetSystemRoleDetailData(long RoleId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.GetSystemRoleDetailData(RoleId);
                return Resp;
            });
        }

        public Task<IEnumerable<SystemPermissions>> GetSystemUserPermissions(long StaffId, bool Isportal)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.GetSystemUserPermissions(StaffId, Isportal);
                return Resp;
            });
        }
        #endregion

        #region System Staff
        public Task<IEnumerable<SystemStaffsData>> GetSystemStaffsData(long TenantId, int Offset, int Count)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.GetSystemStaffsData(TenantId, Offset, Count);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterSystemStaff(SystemStaffs obj)
        {
            return Task.Run(() =>
            {
                string Passwordhash = str.RandomString(12);
                string Password = str.RandomString(8).ToString();
                obj.Passwords = sec.Encrypt(Password, Passwordhash);
                obj.Passharsh = Passwordhash;
                var Response = db.SecurityRepository.RegisterSystemStaff(JsonConvert.SerializeObject(obj));
                if (Response.Data8 == "Insert")
                {
                    var Resp = db.SecurityRepository.Resendsystemstaffpassword(Convert.ToInt64(Response.Data1));
                    if (Resp.Userid >= 1)
                    {
                        var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Staffregistrationtemplate");
                        if (commtempdata != null)
                        {
                            StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                            StrBodyEmail.Replace("@CompanyLogo", Resp.TenantLogo);
                            StrBodyEmail.Replace("@CompanyName", Resp.Tenantname);
                            StrBodyEmail.Replace("@CompanyEmail", Resp.TenantEmail);
                            StrBodyEmail.Replace("@Fullname", Resp.Firstname + " " + Resp.Lastname);
                            StrBodyEmail.Replace("@Username", Resp.Username);
                            StrBodyEmail.Replace("@Password", sec.Decrypt(Resp.Passwords, Resp.Passharsh));
                            StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                            string message = StrBodyEmail.ToString();
                            //log Email Messages
                            EmailLogs Logs = new EmailLogs
                            {
                                EmailLogId = 0,
                                TenantId = Resp.Tenantid,
                                EmailAddress = Resp.Emailaddress,
                                EmailSubject = commtempdata.Templatesubject + " - " + Resp.Tenantname.ToUpper(),
                                EmailMessage = message,
                                IsEmailSent = false,
                                DateTimeSent = DateTime.Now,
                                Datecreated = DateTime.Now,
                            };
                            var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                            bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Emailaddress, commtempdata.Templatesubject+" - "+ Resp.Tenantname.ToUpper(), message, true, Resp.EmailServer, Resp.EmailServerEmail, Resp.EmailPassword);
                            if (data)
                            {
                                Response.RespStatus = 0;
                                Response.RespMessage = "Email Sent";
                            }
                            else
                            {
                                Response.RespStatus = 1;
                                Response.RespMessage = "Email not Sent";
                            }
                        }
                        else
                        {
                            Response.RespStatus = 1;
                            Response.RespMessage = "Template not found!";
                        }
                    }
                    else
                    {
                        Response.RespStatus = 1;
                        Response.RespMessage = "Staff not found!";
                    }
                }
                else
                {
                    Response.RespStatus = Response.RespStatus;
                    Response.RespMessage = Response.RespMessage;
                }
                return Response;
            });
        }

        public Task<Genericmodel> Registersystemstaffdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.Registersystemstaffdata(JsonObj);
                if (Resp.RespStatus == 0)
                {
                    if (Resp.Data8 == "Insert")
                    {
                        var RespData = db.SecurityRepository.Resendsystemstaffpassword(Convert.ToInt64(Resp.Data1));
                        if (RespData.Userid >= 1)
                        {
                            var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Staffregistrationtemplate");
                            if (commtempdata != null)
                            {
                                StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                                StrBodyEmail.Replace("@CompanyLogo", RespData.TenantLogo);
                                StrBodyEmail.Replace("@CompanyName", RespData.Tenantname);
                                StrBodyEmail.Replace("@CompanyEmail", RespData.TenantEmail);
                                StrBodyEmail.Replace("@Fullname", RespData.Firstname + " " + RespData.Lastname);
                                StrBodyEmail.Replace("@Username", RespData.Username);
                                StrBodyEmail.Replace("@Password", sec.Decrypt(RespData.Passwords, RespData.Passharsh));
                                StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                                string message = StrBodyEmail.ToString();
                                //log Email Messages
                                EmailLogs Logs = new EmailLogs
                                {
                                    EmailLogId = 0,
                                    TenantId = RespData.Tenantid,
                                    EmailAddress = RespData.Emailaddress,
                                    EmailSubject = commtempdata.Templatesubject,
                                    EmailMessage = message,
                                    IsEmailSent = false,
                                    DateTimeSent = DateTime.Now,
                                    Datecreated = DateTime.Now,
                                };
                                var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                                bool data = emlsnd.UttambsolutionssendemailAsync(RespData.Emailaddress, commtempdata.Templatesubject, message, true, RespData.EmailServer, RespData.EmailServerEmail, RespData.EmailPassword);
                                if (data)
                                {
                                    Resp.RespStatus = 0;
                                    Resp.RespMessage = "Email Sent";
                                }
                                else
                                {
                                    Resp.RespStatus = 1;
                                    Resp.RespMessage = "Email not Sent";
                                }
                            }
                            else
                            {
                                Resp.RespStatus = 1;
                                Resp.RespMessage = "Template not found!";
                            }
                        }
                        else
                        {
                            Resp.RespStatus = 1;
                            Resp.RespMessage = "Staff not found!";
                        }
                    }
                }
                return Resp;
            });
        }
        public Task<SystemStaffs> GetSystemStaffById(long StaffId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.GetSystemStaffById(StaffId);
                return Resp;
            });
        }
        public Task<Genericmodel> Resendsystemstaffpassword(long StaffId)
        {
            Genericmodel Response = new Genericmodel();
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.Resendsystemstaffpassword(StaffId);
                if (Resp.Userid>=1)
                {
                    //send Card Assignment Email
                    var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Staffforgotpasswordtemplate");
                    if (commtempdata != null)
                    {
                        StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                        StrBodyEmail.Replace("@CompanyLogo", Resp.TenantLogo);
                        StrBodyEmail.Replace("@CompanyName", Resp.Tenantname);
                        StrBodyEmail.Replace("@CompanyEmail", Resp.TenantEmail);
                        StrBodyEmail.Replace("@Fullname", Resp.Firstname + " " + Resp.Lastname);
                        StrBodyEmail.Replace("@Username", Resp.Username);
                        StrBodyEmail.Replace("@Password", sec.Decrypt(Resp.Passwords, Resp.Passharsh));
                        StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                        string message = StrBodyEmail.ToString();
                        //log Email Messages
                        EmailLogs Logs = new EmailLogs
                        {
                            EmailLogId = 0,
                            TenantId = Resp.Tenantid,
                            EmailAddress = Resp.Emailaddress,
                            EmailSubject = commtempdata.Templatesubject,
                            EmailMessage = message,
                            IsEmailSent = false,
                            DateTimeSent = DateTime.Now,
                            Datecreated = DateTime.Now,
                        };
                        var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                        bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Emailaddress, commtempdata.Templatesubject, message, true,Resp.EmailServer,Resp.EmailServerEmail,Resp.EmailPassword);
                        if (data)
                        {
                            Response.RespStatus = 0;
                            Response.RespMessage = "Email Sent";
                        }
                        else
                        {
                            Response.RespStatus = 1;
                            Response.RespMessage = "Email not Sent";
                        }
                    }
                    else
                    {
                        Response.RespStatus = 1;
                        Response.RespMessage = "Template not found!";
                    }
                }
                else
                {
                    Response.RespStatus = 1;
                    Response.RespMessage = "Staff not found!";
                }

                return Response;
            });
        }
        public Task<Genericmodel> Resetuserpasswordpost(Staffresetpassword JsonObj)
        {
            return Task.Run(() =>
            {
                string EncryptionKey = str.RandomString(12);
                string Encryptedpassword = sec.Encrypt(JsonObj.Passwords, EncryptionKey);
                JsonObj.Passwords = Encryptedpassword;
                JsonObj.Passwordhash = EncryptionKey;
                var Response = db.SecurityRepository.Resetuserpasswordpost(JsonConvert.SerializeObject(JsonObj));
                var Resp = db.SecurityRepository.Resendsystemstaffpassword(JsonObj.Userid);
                if (Resp.Userid >= 1)
                {
                    var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Staffforgotpasswordtemplate");
                    if (commtempdata != null)
                    {
                        StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                        StrBodyEmail.Replace("@CompanyLogo", Resp.TenantLogo);
                        StrBodyEmail.Replace("@CompanyName", Resp.Tenantname);
                        StrBodyEmail.Replace("@CompanyEmail", Resp.TenantEmail);
                        StrBodyEmail.Replace("@Fullname", Resp.Firstname + " " + Resp.Lastname);
                        StrBodyEmail.Replace("@Username", Resp.Username);
                        StrBodyEmail.Replace("@Password", sec.Decrypt(Resp.Passwords, Resp.Passharsh));
                        StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                        string message = StrBodyEmail.ToString();
                        //log Email Messages
                        EmailLogs Logs = new EmailLogs
                        {
                            EmailLogId = 0,
                            TenantId = Resp.Tenantid,
                            EmailAddress = Resp.Emailaddress,
                            EmailSubject = commtempdata.Templatesubject,
                            EmailMessage = message,
                            IsEmailSent = false,
                            DateTimeSent = DateTime.Now,
                            Datecreated = DateTime.Now,
                        };
                        var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                        bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Emailaddress, commtempdata.Templatesubject, message, true, Resp.EmailServer, Resp.EmailServerEmail, Resp.EmailPassword);
                        if (data)
                        {
                            Response.RespStatus = 0;
                            Response.RespMessage = "Email Sent";
                        }
                        else
                        {
                            Response.RespStatus = 1;
                            Response.RespMessage = "Email not Sent";
                        }
                    }
                    else
                    {
                        Response.RespStatus = 1;
                        Response.RespMessage = "Template not found!";
                    }
                }
                else
                {
                    Response.RespStatus = 1;
                    Response.RespMessage = "Staff not found!";
                }
                return Response;
            });
        }

        #endregion

        #region Communication Templates
        public Task<IEnumerable<Communicationtemplatedata>> Getsystemcommunicationtemplatedata()
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Getsystemcommunicationtemplatedata();
                return Resp;
            });
        }
        public Task<CommunicationTemplateModel> Getsystemcommunicationtemplatedatabymodule(string Moduledata)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Getsystemcommunicationtemplatedatabymodule(Moduledata);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemcommunicationtemplatedata(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Registersystemcommunicationtemplatedata(obj);
                return Resp;
            });
        }
        public Task<Communicationtemplate> Getsystemcommunicationtemplatedatabyid(long TemplateId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SettingsRepository.Getsystemcommunicationtemplatedatabyid(TemplateId);
                return Resp;
            });
        }
        #endregion

        #region Customer Data

        public Task<IEnumerable<SystemCustomerModel>> GetSystemCustomerData(long TenantId, int Offset, int Count)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerData(TenantId,Offset, Count);
                return Resp;
            });
        }
        public Task<IEnumerable<SystemCustomerModel>> GetSystemCustomerData(long TenantId, string SearchParam, int Offset, int Count)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerData(TenantId, SearchParam, Offset, Count);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerData(SystemCustomer obj)
        {
            return Task.Run(() =>
            {
                string Passwordhash = str.RandomString(12);
                string Password = str.RandomString(8).ToString();
                obj.Pin = sec.Encrypt(Password, Passwordhash);
                obj.Pinharsh = Passwordhash;
                var Resp = db.CustomerRepository.RegisterCustomerData(JsonConvert.SerializeObject(obj));
                if (Resp.RespStatus == 0 && Resp.Data2 == "Insert")
                {
                    var RespData = db.CustomerRepository.GetSystemCompanyCustomerData(Convert.ToInt64(Resp.Data1));
                    if (RespData.CustomerId >= 1)
                    {
                        var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Customerboaringtemplate");
                        if (commtempdata != null)
                        {
                            StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                            StrBodyEmail.Replace("@CompanyLogo", RespData.TenantLogo);
                            StrBodyEmail.Replace("@CompanyName", RespData.TenantName);
                            StrBodyEmail.Replace("@CompanyEmail", RespData.TenantEmail);
                            StrBodyEmail.Replace("@Fullname", RespData.CustomerName);
                            StrBodyEmail.Replace("@Username", RespData.Emailaddress);
                            StrBodyEmail.Replace("@Password", sec.Decrypt(RespData.Pin, RespData.Pinharsh));
                            StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                            string message = StrBodyEmail.ToString();
                            //log Email Messages
                            EmailLogs Logs = new EmailLogs
                            {
                                EmailLogId = 0,
                                TenantId = RespData.TenantId,
                                EmailAddress = RespData.Emailaddress,
                                EmailSubject = commtempdata.Templatesubject + " - " + RespData.TenantName.ToUpper(),
                                EmailMessage = message,
                                IsEmailSent = false,
                                DateTimeSent = DateTime.Now,
                                Datecreated = DateTime.Now,
                            };
                            var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                            bool data = emlsnd.UttambsolutionssendemailAsync(RespData.Emailaddress, commtempdata.Templatesubject +" - " + RespData.TenantName.ToUpper(), message, true, RespData.EmailServer, RespData.EmailServerEmail, RespData.EmailPassword);
                            if (data)
                            {
                                Resp.RespStatus = 0;
                                Resp.RespMessage = "Email Sent";
                            }
                            else
                            {
                                Resp.RespStatus = 1;
                                Resp.RespMessage = "Email not Sent";
                            }
                        }
                        else
                        {
                            Resp.RespStatus = 1;
                            Resp.RespMessage = "Template not found!";
                        }
                    }
                    else
                    {
                        Resp.RespStatus = 1;
                        Resp.RespMessage = "Staff not found!";
                    }
                }
                return Resp;
            });
        }
        public Task<SystemCustomer> GetSystemCustomerData(long CustomerId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCompanyCustomerData(CustomerId);
                return Resp;
            });
        }
        public Task<SystemCustomerDetails> GetSystemCustomerDetailData(long CustomerId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerDetailData(CustomerId);
                return Resp;
            });
        }
        public Task<CustomerCardDetailsData> GetSystemCustomerAccountCardDetailData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerAccountCardDetailData(obj);
                return Resp;
            });
        }
        public Task<Genericmodel> Resendcustomerpassword(long CustomerId)
        {
            Genericmodel Resp = new Genericmodel();
            return Task.Run(() =>
            {
                var RespData = db.CustomerRepository.GetSystemCompanyCustomerData(CustomerId);
                if (RespData.CustomerId >= 1)
                {
                    var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Customerboaringtemplate");
                    if (commtempdata != null)
                    {
                        StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                        StrBodyEmail.Replace("@CompanyLogo", RespData.TenantLogo);
                        StrBodyEmail.Replace("@CompanyName", RespData.TenantName);
                        StrBodyEmail.Replace("@CompanyEmail", RespData.TenantEmail);
                        StrBodyEmail.Replace("@Fullname", RespData.CustomerName);
                        StrBodyEmail.Replace("@Username", RespData.Emailaddress);
                        StrBodyEmail.Replace("@Password", sec.Decrypt(RespData.Pin, RespData.Pinharsh));
                        StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                        string message = StrBodyEmail.ToString();
                        //log Email Messages
                        EmailLogs Logs = new EmailLogs
                        {
                            EmailLogId = 0,
                            TenantId = RespData.TenantId,
                            EmailAddress = RespData.Emailaddress,
                            EmailSubject = commtempdata.Templatesubject + " - " + RespData.TenantName.ToUpper(),
                            EmailMessage = message,
                            IsEmailSent = false,
                            DateTimeSent = DateTime.Now,
                            Datecreated = DateTime.Now,
                        };
                        var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                        bool data = emlsnd.UttambsolutionssendemailAsync(RespData.Emailaddress, commtempdata.Templatesubject + " - " + RespData.TenantName.ToUpper(), message, true, RespData.EmailServer, RespData.EmailServerEmail, RespData.EmailPassword);
                        if (data)
                        {
                            Resp.RespStatus = 0;
                            Resp.RespMessage = "Email Sent";
                        }
                        else
                        {
                            Resp.RespStatus = 1;
                            Resp.RespMessage = "Email not Sent";
                        }
                    }
                    else
                    {
                        Resp.RespStatus = 1;
                        Resp.RespMessage = "Template not found!";
                    }
                }
                else
                {
                    Resp.RespStatus = 1;
                    Resp.RespMessage = "Staff not found!";
                }
                return Resp;
            });
        }
        #endregion

        #region Customer Agreements
        public Task<Genericmodel> RegisterCustomerPrepaidAgreementData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerPrepaidAgreementData(obj);
                return Resp;
            });
        }
        public Task<CustomerPrepaidAgreement> Getcustomerprepaidagreementdatabyid(long CustomerAgreementId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomerprepaidagreementdatabyid(CustomerAgreementId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerPostpaidRecurrentAgreementData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerPostpaidRecurrentAgreementData(obj);
                return Resp;
            });
        }

        public Task<Genericmodel> RegisterCustomerPostpaidOneoffAgreementData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerPostpaidOneoffAgreementData(obj);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerPostpaidCreditAgreementData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerPostpaidCreditAgreementData(obj);
                return Resp;
            });
        }
        public Task<CustomerCreditAgreement> Getcustomerpostpaidcreditagreementdatabyid(long CustomerAgreementId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomerpostpaidcreditagreementdatabyid(CustomerAgreementId);
                return Resp;
            });
        }

        #endregion

        #region Customer Agreement Topups
        public Task<IEnumerable<CustomerAccountTopups>> GetSystemCustomerAgreementtopuptransferData(long Agreementaccountid)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerAgreementtopuptransferData(Agreementaccountid);
                return Resp;
            });
        }
        #endregion

        #region Customer Agreements Payments
        public Task<Genericmodel> RegisterCustomerAgreementPaymentData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementPaymentData(obj);
                return Resp;
            });
        }
        public Task<IEnumerable<CustomerAgreementPayments>> GetSystemCustomerAgreementPaymentListData(long Agreementid)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerAgreementPaymentListData(Agreementid);
                return Resp;
            });
        }
        #endregion

        #region Reverse Topup and Payments
        public Task<Genericmodel> PostReverseTopupTransactionData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.PostReverseTopupTransactionData(obj);
                //if (Resp.RespStatus==0)
                //{
                //    //send Sale Email
                //    var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Sale");
                //    if (commtempdata != null)
                //    {
                //        StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                //        //StrBodyEmail.Replace("@name", Resp..customerName);
                //        //StrBodyEmail.Replace("@accountType", saharaNotificationParams.identifier);
                //        //StrBodyEmail.Replace("@tenant", saharaNotificationParams.tenant);
                //        //StrBodyEmail.Replace("@identifier", saharaNotificationParams.accountMask);
                //        //StrBodyEmail.Replace("@amount", saharaNotificationParams.amount.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@location", saharaNotificationParams.location);
                //        //StrBodyEmail.Replace("@liters", saharaNotificationParams.units.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@product", saharaNotificationParams.productName);
                //        //StrBodyEmail.Replace("@prolist", saharaNotificationParams.products);
                //        //StrBodyEmail.Replace("@balance", saharaNotificationParams.accountBalance.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@customerBalance", saharaNotificationParams.customerBalance.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@reward", saharaNotificationParams.rewardName);
                //        //StrBodyEmail.Replace("@rwdamtn", saharaNotificationParams.rewardAmount.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@total", saharaNotificationParams.rewardTotalAmount.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@paymentmode", saharaNotificationParams.paymentMode);
                //        //StrBodyEmail.Replace("@agreementdescription", saharaNotificationParams.agreementDescription);
                //        //StrBodyEmail.Replace("@transcode", saharaNotificationParams.transactionCode);
                //        //StrBodyEmail.Replace("@accountNo", saharaNotificationParams.accountNumber.ToString());
                //        string message = StrBodyEmail.ToString();
                //        bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Data4, commtempdata.Templatesubject, message, true);
                //        if (data)
                //        {
                //            Resp.RespStatus = 0;
                //            Resp.RespMessage = "Email Sent";
                //        }
                //        else
                //        {
                //            Resp.RespStatus = 1;
                //            Resp.RespMessage = "Email not Sent";
                //        }
                //    }
                //    else
                //    {
                //        Resp.RespStatus = 1;
                //        Resp.RespMessage = "Template not found!";
                //    }

                //}
                return Resp;
            });
        }
        public Task<Genericmodel> PostReversePaymentTransactionData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.PostReversePaymentTransactionData(obj);
                //if (Resp.RespStatus==0)
                //{
                //    //send Sale Email
                //    var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Sale");
                //    if (commtempdata != null)
                //    {
                //        StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                //        //StrBodyEmail.Replace("@name", Resp..customerName);
                //        //StrBodyEmail.Replace("@accountType", saharaNotificationParams.identifier);
                //        //StrBodyEmail.Replace("@tenant", saharaNotificationParams.tenant);
                //        //StrBodyEmail.Replace("@identifier", saharaNotificationParams.accountMask);
                //        //StrBodyEmail.Replace("@amount", saharaNotificationParams.amount.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@location", saharaNotificationParams.location);
                //        //StrBodyEmail.Replace("@liters", saharaNotificationParams.units.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@product", saharaNotificationParams.productName);
                //        //StrBodyEmail.Replace("@prolist", saharaNotificationParams.products);
                //        //StrBodyEmail.Replace("@balance", saharaNotificationParams.accountBalance.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@customerBalance", saharaNotificationParams.customerBalance.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@reward", saharaNotificationParams.rewardName);
                //        //StrBodyEmail.Replace("@rwdamtn", saharaNotificationParams.rewardAmount.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@total", saharaNotificationParams.rewardTotalAmount.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@paymentmode", saharaNotificationParams.paymentMode);
                //        //StrBodyEmail.Replace("@agreementdescription", saharaNotificationParams.agreementDescription);
                //        //StrBodyEmail.Replace("@transcode", saharaNotificationParams.transactionCode);
                //        //StrBodyEmail.Replace("@accountNo", saharaNotificationParams.accountNumber.ToString());
                //        string message = StrBodyEmail.ToString();
                //        bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Data4, commtempdata.Templatesubject, message, true);
                //        if (data)
                //        {
                //            Resp.RespStatus = 0;
                //            Resp.RespMessage = "Email Sent";
                //        }
                //        else
                //        {
                //            Resp.RespStatus = 1;
                //            Resp.RespMessage = "Email not Sent";
                //        }
                //    }
                //    else
                //    {
                //        Resp.RespStatus = 1;
                //        Resp.RespMessage = "Template not found!";
                //    }

                //}
                return Resp;
            });
        }

        #endregion

        #region Customer Agreements Accounts
        public Task<Genericmodel> RegisterCustomerAgreementAccountData(CustomerAgreementAccountData obj)
        {
            return Task.Run(() =>
            {
                string Passwordhash = str.RandomString(12);
                string Password = str.RandomNumber(1, 10000).ToString();
                obj.Pin = sec.Encrypt(Password, Passwordhash);
                obj.Pinharsh = Passwordhash;
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountData(JsonConvert.SerializeObject(obj));
                if (Resp.RespStatus == 0)
                {
                    //send Card Assignment Email
                    var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Customercardassignment");
                    if (commtempdata != null)
                    {
                        var Settings = db.SettingsRepository.Getsystemtenantaccountbytenantid(Convert.ToInt32(Resp.Data7));
                        StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                        StrBodyEmail.Replace("@CompanyLogo", Settings.TenantLogo);
                        StrBodyEmail.Replace("@CompanyName", Settings.Tenantname);
                        StrBodyEmail.Replace("@CompanyEmail", Settings.TenantEmail);
                        StrBodyEmail.Replace("@Fullname", Resp.Data1);
                        StrBodyEmail.Replace("@Cardmask", Resp.Data3);
                        StrBodyEmail.Replace("@Cardpin", sec.Decrypt(Resp.Data4, Resp.Data5));
                        StrBodyEmail.Replace("@Cardcode", Resp.Data6);
                        StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                        string message = StrBodyEmail.ToString();
                        //log Email Messages
                        EmailLogs Logs = new EmailLogs
                        {
                            EmailLogId = 0,
                            TenantId = Convert.ToInt32(Resp.Data7),
                            EmailAddress = Resp.Data2,
                            EmailSubject = commtempdata.Templatesubject,
                            EmailMessage = message,
                            IsEmailSent = false,
                            DateTimeSent = DateTime.Now,
                            Datecreated = DateTime.Now,
                        };
                        var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                        bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Data2, commtempdata.Templatesubject, message, true, Settings.EmailServer, Settings.EmailAddress, Settings.EmailPassword);
                        if (data)
                        {
                            Resp.RespStatus = 0;
                            Resp.RespMessage = "Email Sent";
                        }
                        else
                        {
                            Resp.RespStatus = 1;
                            Resp.RespMessage = "Email not Sent";
                        }
                    }
                    else
                    {
                        Resp.RespStatus = 1;
                        Resp.RespMessage = "Template not found!";
                    }

                }
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountTopupData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountTopupData(obj);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountTransferData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountTransferData(obj);
                return Resp;
            });
        }
        public Task<SystemAccountDetailData> GetSystemCustomerAccountDetailData(long AccountId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerAccountDetailData(AccountId);
                return Resp;
            });
        }
        public Task<SystemAccountDetailData> GetSystemCustomerAccountDetailData(string CardNumber)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerAccountDetailData(CardNumber);
                return Resp;
            });
        }
        public Task<SystemCustomerAndAccountDetailData> GetSystemCustomerAndAccountDetailData(Systemcustomercarddata obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerAndAccountDetailData(obj);
                Resp.SelectedCustomerorDriver = obj.SelectedCustomerorDriver;
                return Resp;
            });
        }

        #region Replace Customer Account Mask
        public Task<Genericmodel> Replacecustomeraccountcarddata(AccountCardReplaceDetails obj)
        {
            return Task.Run(() =>
            {
                string Passwordhash = str.RandomString(12);
                string Password = str.RandomNumber(1, 10000).ToString();
                obj.Pin = sec.Encrypt(Password, Passwordhash);
                obj.Pinharsh = Passwordhash;
                var Resp = db.CustomerRepository.Replacecustomeraccountcarddata(JsonConvert.SerializeObject(obj));
                return Resp;
            });
        }
        #endregion

        #region Customer account Policy
        public Task<CustomerAccountDetails> GetSystemCustomerAccountPolicyDetailData(long AccountId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerAccountPolicyDetailData(AccountId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountProductPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountProductPolicyData(obj);
                return Resp;
            });
        }
        public Task<AccountProductpolicy> GetcustomeraccountproductpolicyData(long AccountProductId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetcustomeraccountproductpolicyData(AccountProductId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountStationPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountStationPolicyData(obj);
                return Resp;
            });
        }
        public Task<AccountStationspolicy> Getcustomeraccountstationpolicydata(long AccountStationId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomeraccountstationpolicydata(AccountStationId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountWeekdayPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountWeekdayPolicyData(obj);
                return Resp;
            });
        }
        public Task<AccountWeekDayspolicy> Getcustomeraccountweekdaypolicydata(long AccountWeekDaysId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomeraccountweekdaypolicydata(AccountWeekDaysId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountFrequencyPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountFrequencyPolicyData(obj);
                return Resp;
            });
        }
        public Task<AccountTransactionFrequencypolicy> Getcustomeraccountfrequencypolicydata(long AccountFrequencyId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomeraccountfrequencypolicydata(AccountFrequencyId);
                return Resp;
            });
        }
        #endregion

        #region Customer account Employee Policy
        public Task<Genericmodel> RegisterCustomerAccountEmployeeData(CustomerAccountEmployees obj)
        {
            return Task.Run(() =>
            {
                string EncryptionKey = str.RandomString(12);
                string Employeecode = str.RandomNumber(0, 5).ToString();
                obj.Employeecode = sec.Encrypt(Employeecode, EncryptionKey);
                obj.Employeeharhcode = EncryptionKey;
                var Resp = db.CustomerRepository.RegisterCustomerAccountEmployeeData(JsonConvert.SerializeObject(obj));
                return Resp;
            });
        }
        public Task<CustomerAccountEmployees> GetCustomerAccountEmployeeById(long EmployeeId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetCustomerAccountEmployeeById(EmployeeId);
                return Resp;
            });
        }
        public Task<CustomerAccountEmployeePolicyDetails> GetSystemCustomerAccountEmployeePolicyDetailData(long EmployeeId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerAccountEmployeePolicyDetailData(EmployeeId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountEmployeeProductPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountEmployeeProductPolicyData(obj);
                return Resp;
            });
        }
        public Task<AccountEmployeeProductpolicy> Getcustomeraccountemployeeproductpolicydata(long EmployeeProductId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomeraccountemployeeproductpolicydata(EmployeeProductId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountEmployeeStationPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountEmployeeStationPolicyData(obj);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountEmployeeWeekdayPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountEmployeeWeekdayPolicyData(obj);
                return Resp;
            });
        }
        public Task<AccountEmployeeWeekDayspolicy> Getcustomeraccountemployeeweekdaypolicydata(long EmployeeweekdayId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomeraccountemployeeweekdaypolicydata(EmployeeweekdayId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountEmployeeFrequencyPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountEmployeeFrequencyPolicyData(obj);
                return Resp;
            });
        }
        public Task<AccountEmployeeTransactionFrequencypolicy> Getcustomeraccountemployeefrequencypolicydata(long EmployeefrequencyId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomeraccountemployeefrequencypolicydata(EmployeefrequencyId);
                return Resp;
            });
        }
        #endregion

        #endregion

        #region System Customer Account Equipment
        public Task<Genericmodel> RegisterCustomerAccountEquipmentData(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAccountEquipmentData(JsonObj);
                return Resp;
            });
        }
        public Task<CustomerAccountEquipments> GetSystemCustomerAccountEquipmentData(long EquipmentId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerAccountEquipmentData(EquipmentId);
                return Resp;
            });
        }

        public Task<CustomerAccountEquipmentPolicyDetails> GetSystemCustomerAccountEquipmentPolicyDetailData(long EquipmentId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.GetSystemCustomerAccountEquipmentPolicyDetailData(EquipmentId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountEquipmentProductPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountEquipmentProductPolicyData(obj);
                return Resp;
            });
        }
        public Task<AccountEquipmentProductpolicy> Getcustomeraccountequipmentproductpolicydata(long EquipmentProductId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomeraccountequipmentproductpolicydata(EquipmentProductId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountEquipmentStationPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountEquipmentStationPolicyData(obj);
                return Resp;
            });
        }

        public Task<Genericmodel> RegisterCustomerAgreementAccountEquipmentWeekdayPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountEquipmentWeekdayPolicyData(obj);
                return Resp;
            });
        }
        public Task<AccountEquipmentWeekDayspolicy> Getcustomeraccountequipmentweekdaypolicydata(long EquipmentWeekDaysId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomeraccountequipmentweekdaypolicydata(EquipmentWeekDaysId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterCustomerAgreementAccountEquipmentFrequencyPolicyData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.RegisterCustomerAgreementAccountEquipmentFrequencyPolicyData(obj);
                return Resp;
            });
        }
        public Task<AccountEquipmentTransactionFrequencypolicy> Getcustomeraccountequipmentfrequencypolicydata(long EquipmentFrequencyId)
        {
            return Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomeraccountequipmentfrequencypolicydata(EquipmentFrequencyId);
                return Resp;
            });
        }
        #endregion

        #region Post Sales Transaction
        public Task<SingleFinanceTransactions> PostSaleTransaction(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SalesTransactionRepository.PostSaleTransaction(obj);
                if (Resp.RespStatus == 0)
                {

                    var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Customersaletransactiontemplate");
                    if (commtempdata != null)
                    {
                        var Settings = db.SettingsRepository.Getsystemtenantaccountbytenantid(Convert.ToInt32(Resp.Tenantid));
                        StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                        StrBodyEmail.Replace("@CompanyLogo", Settings.TenantLogo);
                        StrBodyEmail.Replace("@CompanyName", Settings.Tenantname);
                        StrBodyEmail.Replace("@CompanyEmail", Settings.TenantEmail);
                        StrBodyEmail.Replace("@Fullname", Resp.Customername);
                        StrBodyEmail.Replace("@accountType", Resp.Groupingname);
                        StrBodyEmail.Replace("@CustomerCard", Resp.CustomerCard + "  -  " + Resp.CardCode);
                        StrBodyEmail.Replace("@EverestCard", Resp.FuelProCard.ToString("#,##0.00"));
                        StrBodyEmail.Replace("@StationName", Resp.StationName);
                        StrBodyEmail.Replace("@Paymentmode", Resp.Paymentmode);
                        StrBodyEmail.Replace("@Liters", Resp.Ticketlines.Sum(x => x.Units).ToString("#,##0.00"));
                        StringBuilder tableHtml = new StringBuilder();
                        tableHtml.Append("<table  style=\"width: 100%; border-collapse: collapse;\">");
                        tableHtml.Append("<thead><tr><th style=\"border: 1px solid #ddd; padding: 8px;\">Item</th><th style=\"border: 1px solid #ddd; padding: 8px;\">Unit</th><th style=\"border: 1px solid #ddd; padding: 8px;\">Price</th><th style=\"border: 1px solid #ddd; padding: 8px;\">Discount</th><th style=\"border: 1px solid #ddd; padding: 8px;\">Total</th></tr></thead>");
                        tableHtml.Append("<tbody>");

                        foreach (var ticketLine in Resp.Ticketlines)
                        {
                            tableHtml.Append("<tr>");
                            tableHtml.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{ticketLine.Productvariationname}</td>");
                            tableHtml.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{ticketLine.Units.ToString("#,##0.00")}</td>");
                            tableHtml.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{ticketLine.Price.ToString("#,##0.00")}</td>");
                            tableHtml.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{Resp.Currencyname+". "+ ticketLine.Discount.ToString("#,##0.00")}</td>");
                            tableHtml.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{Resp.Currencyname + ". " + (ticketLine.Units * ticketLine.Price).ToString("#,##0.00")}</td>");
                            tableHtml.Append("</tr>");
                        }
                        tableHtml.Append("<tr>");
                        tableHtml.Append($"<td colspan=\"4\" style=\"border: 1px solid #ddd; padding: 8px;\">Total: </td>");
                        tableHtml.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{Resp.Currencyname + ". " + Resp.Total.ToString("#,##0.00")}</td>");
                        tableHtml.Append("</tr>");
                        tableHtml.Append("</tbody></table>");


                        StrBodyEmail.Replace("@EverestTicketLines", tableHtml.ToString());
                        StrBodyEmail.Replace("@CardBalance", Resp.Currencyname + ". " + Resp.CardBalance.ToString("#,##0.00"));
                        StrBodyEmail.Replace("@CustomerBalance", Resp.Currencyname + ". " + Resp.CustomerBalance.ToString("#,##0.00"));
                        StrBodyEmail.Replace("@reward", Resp.RewardName);
                        StrBodyEmail.Replace("@CurrentPoints", Resp.CurrentPoints.ToString("#,##0.00"));
                        StrBodyEmail.Replace("@CumulativePoints", Resp.CumulativePoints.ToString("#,##0.00"));
                        StrBodyEmail.Replace("@paymentmode", Resp.Paymentmode);
                        StrBodyEmail.Replace("@agreementdescription", Resp.Agreementtypename);
                        StrBodyEmail.Replace("@transcode", Resp.TransactionCode);
                        StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                        string message = StrBodyEmail.ToString();
                        //log Email Messages
                        EmailLogs Logs = new EmailLogs
                        {
                            EmailLogId = 0,
                            TenantId = Resp.Tenantid,
                            EmailAddress = Resp.Emailaddress,
                            EmailSubject = Resp.Customername.ToUpper() + "-" + commtempdata.Templatesubject,
                            EmailMessage = message,
                            IsEmailSent = false,
                            DateTimeSent = DateTime.Now,
                            Datecreated = DateTime.Now,
                        };
                        var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                        bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Emailaddress, Resp.Customername.ToUpper() + "-"+commtempdata.Templatesubject, message, true, Settings.EmailServer, Settings.EmailAddress, Settings.EmailPassword);
                        if (data)
                        {
                            Resp.RespStatus = 0;
                            Resp.RespMessage = "Email Sent";
                        }
                        else
                        {
                            Resp.RespStatus = 0;
                            Resp.RespMessage = "Email not Sent";
                        }
                    }
                    else
                    {
                        Resp.RespStatus = 0;
                        Resp.RespMessage = "Template not found!";
                    }
                }
                return Resp;
            });
        }

        public Task<Genericmodel> PostReverseSaleTransactionData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SalesTransactionRepository.PostReverseSaleTransactionData(obj);
                //if (Resp.RespStatus==0)
                //{
                //    //send Sale Email
                //    var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Sale");
                //    if (commtempdata != null)
                //    {
                //        StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                //        //StrBodyEmail.Replace("@name", Resp..customerName);
                //        //StrBodyEmail.Replace("@accountType", saharaNotificationParams.identifier);
                //        //StrBodyEmail.Replace("@tenant", saharaNotificationParams.tenant);
                //        //StrBodyEmail.Replace("@identifier", saharaNotificationParams.accountMask);
                //        //StrBodyEmail.Replace("@amount", saharaNotificationParams.amount.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@location", saharaNotificationParams.location);
                //        //StrBodyEmail.Replace("@liters", saharaNotificationParams.units.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@product", saharaNotificationParams.productName);
                //        //StrBodyEmail.Replace("@prolist", saharaNotificationParams.products);
                //        //StrBodyEmail.Replace("@balance", saharaNotificationParams.accountBalance.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@customerBalance", saharaNotificationParams.customerBalance.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@reward", saharaNotificationParams.rewardName);
                //        //StrBodyEmail.Replace("@rwdamtn", saharaNotificationParams.rewardAmount.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@total", saharaNotificationParams.rewardTotalAmount.ToString("#,##0.00"));
                //        //StrBodyEmail.Replace("@paymentmode", saharaNotificationParams.paymentMode);
                //        //StrBodyEmail.Replace("@agreementdescription", saharaNotificationParams.agreementDescription);
                //        //StrBodyEmail.Replace("@transcode", saharaNotificationParams.transactionCode);
                //        //StrBodyEmail.Replace("@accountNo", saharaNotificationParams.accountNumber.ToString());
                //        string message = StrBodyEmail.ToString();
                //        bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Data4, commtempdata.Templatesubject, message, true);
                //        if (data)
                //        {
                //            Resp.RespStatus = 0;
                //            Resp.RespMessage = "Email Sent";
                //        }
                //        else
                //        {
                //            Resp.RespStatus = 1;
                //            Resp.RespMessage = "Email not Sent";
                //        }
                //    }
                //    else
                //    {
                //        Resp.RespStatus = 1;
                //        Resp.RespMessage = "Template not found!";
                //    }

                //}
                return Resp;
            });
        }
        public Task<IEnumerable<FinanceTransactions>> Getallofflinesalesdata(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SalesTransactionRepository.Getallofflinesalesdata(TenantId);
                return Resp;
            });
        }
        public Task<SingleFinanceTransactions> Getsingleofflinesalesdata(long FinanceTransactionId, long AccountId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SalesTransactionRepository.Getsingleofflinesalesdata(FinanceTransactionId, AccountId);
                return Resp;
            });
        }
        #endregion

        #region Post Automated Transactions
        public Task<Genericmodel> ProcessAutomationsalesData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SalesTransactionRepository.ProcessAutomationsalesData(obj);
                return Resp;
            });
        }

        #endregion

        #region System Product Data
        public Task<IEnumerable<SystemProductModelData>> GetSystemProductvariationData(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductRepository.GetSystemProductvariationData(TenantId);
                return Resp;
            });
        }
        public Task<IEnumerable<SystemProductModelData>> GetSystemStationProductData(long TenantId,long StationId)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductRepository.GetSystemStationProductData(TenantId,StationId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterSystemProduct(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductRepository.RegisterSystemProduct(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> UpdateSystemProduct(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductRepository.UpdateSystemProduct(JsonObj);
                return Resp;
            });
        }
        public Task<SystemProductVariation> GetSystemProductDetailDataById(long ProductVariationId)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductRepository.GetSystemProductDetailDataById(ProductVariationId);
                return Resp;
            });
        }
        #endregion

        #region Main store products
        public Task<IEnumerable<DryStockMainStoreModelData>> Getsystemproductmainstoredata(long TenantId, long StationId)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductRepository.Getsystemproductmainstoredata(TenantId, StationId);
                return Resp;
            });
        }
        public Task<Genericmodel> Savetransfertoaccessoriesdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductRepository.Savetransfertoaccessoriesdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Stations Data
        public Task<IEnumerable<SystemStationData>> GetSystemstationsData(long TenantId,long StationId, int Offset, int Count)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.GetSystemstationsData(TenantId, StationId, Offset, Count);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterSystemStation(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.RegisterSystemStation(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> Automatesystemstationdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Automatesystemstationdata(JsonObj);
                return Resp;
            });
        }
        public Task<IEnumerable<AutomatedStationData>> Getautomatedsystemstationsdata()
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getautomatedsystemstationsdata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationdata(JsonObj);
                return Resp;
            });
        }
        public Task<SystemStations> GetSystemStationDetailDataById(long StationId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.GetSystemStationDetailDataById(StationId);
                return Resp;
            });
        }
        public Task<Systemstationdetailmodel> GetSystemStationallDetailDataById(long StationId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.GetSystemStationallDetailDataById(StationId);
                return Resp;
            });
        }

        #endregion

        #region System Station Tank Dips
        public Task<Genericmodel> Registersystemstationtankdipsdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationtankdipsdata(JsonObj);
                return Resp;
            });
        }
        public Task<StationDailyDip> GetsystemstationtankdetailbyId(long TankId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.GetsystemstationtankdetailbyId(TankId);
                return Resp;
            });
        }
        #endregion

        #region System Station Purchases
        public Task<Genericmodel> Registersystemstationpurchasesdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationpurchasesdata(JsonObj);
                return Resp;
            });
        }
        public Task<StationPurchase> Getsystemstationpurchasesdetailbyid(long PurchaseId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationpurchasesdetailbyid(PurchaseId);
                return Resp;
            });
        }
        #endregion

        #region System station shift
        public Task<SingleStationShiftData> Getsystemstationsingleshiftdata(long StationId,long ShiftId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationsingleshiftdata(StationId, ShiftId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftdata(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftpumpdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftpumpdata(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshifttankdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshifttankdata(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftlubedata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftlubedata(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftlpgdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftlpgdata(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftsparepartdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftsparepartdata(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftcarwashdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftcarwashdata(JsonObj);
                return Resp;
            });
        }
        #region SHift Credit Invoices
        public Task<ShiftCreditInvoiceData> Getsystemstationshiftcreditinvoicedata(long ShiftId, int start, int length, string? searchParam)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftcreditinvoicedata(ShiftId, start, length, searchParam);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftcreditinvoicedata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftcreditinvoicedata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Wetstock Purchase
        public Task<ShiftWetStockPurchaseData> Getsystemstationshiftwetstockpurchasedata(long ShiftId, int start, int length, string? searchParam)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftwetstockpurchasedata(ShiftId, start, length, searchParam);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftwetstockpurchasedata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftwetstockpurchasedata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Drystock Purchase
        public Task<ShiftDryStockPurchaseData> Getsystemstationshiftdrystockpurchasedata(long ShiftId, int start, int length, string? searchParam)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftdrystockpurchasedata(ShiftId, start, length, searchParam);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftdrystockpurchasedata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftdrystockpurchasedata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Station Shift Expenses
        public Task<ShiftExpenseData> Getsystemstationshiftexpensedata(long ShiftId, int start, int length, string? searchParam)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftexpensedata(ShiftId, start, length, searchParam);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftexpensedata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftexpensedata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Mpesa Collection
        public Task<ShiftMpesaCollectionData> Getsystemstationshiftmpesadata(long ShiftId, int start, int length, string? searchParam)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftmpesadata(ShiftId, start, length, searchParam);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftmpesadata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftmpesadata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Fuel Card Collection
        public Task<ShiftFuelCardCollectionData> Getsystemstationshiftfuelcarddata(long ShiftId, int start, int length, string? searchParam)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftfuelcarddata(ShiftId, start, length, searchParam);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftfuelcarddata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftfuelcarddata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Merchant Collections
        public Task<ShiftMerchantCollectionData> Getsystemstationshiftmerchantdata(long ShiftId, int start, int length, string? searchParam)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftmerchantdata(ShiftId, start, length, searchParam);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftmerchantdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftmerchantdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Topups
        public Task<ShiftTopupData> Getsystemstationshifttopupdata(long ShiftId, int start, int length, string? searchParam)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshifttopupdata(ShiftId, start, length, searchParam);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshifttopupdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshifttopupdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Payments
        public Task<ShiftPaymentData> Getsystemstationshiftpaymentdata(long ShiftId, int start, int length, string? searchParam)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftpaymentdata(ShiftId, start, length, searchParam);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftpaymentdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftpaymentdata(JsonObj);
                return Resp;
            });
        }
        #endregion
        public Task<Genericmodel> Closesystemstationshiftdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Closesystemstationshiftdata(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> Supervisorclosesystemstationshiftdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Supervisorclosesystemstationshiftdata(JsonObj);
                return Resp;
            });
        }
        public Task<decimal> Getsystemstationtankshiftpurchasedata(long ShiftId, long TankId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationtankshiftpurchasedata(ShiftId, TankId);
                return Resp;
            });
        }
        public Task<decimal> Getsystemstationdryproductshiftpurchasedata(long ShiftId, long ProductId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationdryproductshiftpurchasedata(ShiftId, ProductId);
                return Resp;
            });
        }
        public Task<decimal> Getsystemstationproductpricedata(long StationId, long ProductId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationproductpricedata(StationId, ProductId);
                return Resp;
            });
        }
        public Task<IEnumerable<SystemStationShift>> Getsystemstationshiftlistdata(long StationId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftlistdata(StationId);
                return Resp;
            });
        }
        public Task<StationShiftDetailData> Getsystemstationshiftdetaildata()
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftdetaildata();
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationshiftvoucherdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationshiftvoucherdata(JsonObj);
                return Resp;
            });
        }
        public Task<ShiftVoucher> Getsystemstationvoucherbyid(long ShiftVoucherId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationvoucherbyid(ShiftVoucherId);
                return Resp;
            });
        }
        public Task<ShiftDetailDataModel> Getsystemstationshiftdetaildata(long ShiftId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationshiftdetaildata(ShiftId);
                return Resp;
            });
        }
        public Task<ProductPriceData> GetsystemdryproductpricebyId(long ProductVariationId,long StationId, long CustomerId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.GetsystemdryproductpricebyId(ProductVariationId, StationId, CustomerId);
                return Resp;
            });
        }
        public Task<ProductVatPriceData> GetsystemproductpricevatbyId(long SupplierId, long ProductId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.GetsystemproductpricevatbyId(SupplierId, ProductId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationlubedata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationlubedata(JsonObj);
                return Resp;
            });
        }
        public Task<ShiftLubesandLpg> Getsystemstationlubeandlpgbyid(long ShiftLubeLpgId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Getsystemstationlubeandlpgbyid(ShiftLubeLpgId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registersystemstationcreditinvoicedata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.Registersystemstationcreditinvoicedata(JsonObj);
                return Resp;
            });
        }
        //public Task<ShiftCreditInvoice> Getsystemcreditinvoicesalebyid(long ShiftCreditInvoiceId)
        //{
        //    return Task.Run(() =>
        //    {
        //        var Resp = db.StationRepository.Getsystemcreditinvoicesalebyid(ShiftCreditInvoiceId);
        //        return Resp;
        //    });
        //}
        #endregion

        #region Ststion Tanks
        public Task<StationTankModel> GetSystemStationTankDetailDataById(long TankId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.GetSystemStationTankDetailDataById(TankId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterSystemStationTank(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.RegisterSystemStationTank(JsonObj);
                return Resp;
            });
        }


        #endregion

        #region Ststion Pump
        public Task<Stationpumps> GetSystemStationpumpDetailDataById(long PumpId)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.GetSystemStationpumpDetailDataById(PumpId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterSystemStationPump(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.StationRepository.RegisterSystemStationPump(JsonObj);
                return Resp;
            });
        }


        #endregion

        #region System Price and Discount List Data
        public Task<SystemPriceListData> GetSystemPriceListData(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.GetSystemPriceListData(TenantId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registerpricelistdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.Registerpricelistdata(JsonObj);
                return Resp;
            });
        }
        public Task<PriceListInfoData> Getsystempricelistdatabyid(long PriceListId)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.Getsystempricelistdatabyid(PriceListId);
                return Resp;
            });
        }
        public Task<Genericmodel> Editsystempricelistdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.Editsystempricelistdata(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> Addpricelistpricenewdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.Addpricelistpricenewdata(JsonObj);
                return Resp;
            });
        }
        public Task<PriceListData> GetSystemCustomerAgreementPriceListData(long PriceListId)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.GetSystemCustomerAgreementPriceListData(PriceListId);
                return Resp;
            });
        }
        public Task<SystemDiscountListData> GetSystemDiscountListData(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.GetSystemDiscountListData(TenantId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registerdiscountlistdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.Registerdiscountlistdata(JsonObj);
                return Resp;
            });
        }

        public Task<DiscountListModelData> Getsystemdiscountlistdatabyid(long DiscountlistId)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.Getsystemdiscountlistdatabyid(DiscountlistId);
                return Resp;
            });
        }
        public Task<Genericmodel> Editsystemdiscountlistdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.Editsystemdiscountlistdata(JsonObj);
                return Resp;
            });
        }
        public Task<Genericmodel> Adddicountlistvaluenewdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.Adddicountlistvaluenewdata(JsonObj);
                return Resp;
            });
        }
        public Task<DiscountListData> GetSystemCustomerAgreementDiscountListData(long DiscountListId)
        {
            return Task.Run(() =>
            {
                var Resp = db.PriceRepository.GetSystemCustomerAgreementDiscountListData(DiscountListId);
                return Resp;
            });
        }
        #endregion

        #region System Hardware Data

        #region System POS
        public Task<IEnumerable<SystemGadgetsData>> GetSystemGadgetsData(int Offset, int Count)
        {
            return Task.Run(() =>
            {
                var Resp = db.SetupRepository.GetSystemGadgetsData(Offset, Count);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterSystemGadgets(string? JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SetupRepository.RegisterSystemGadgets(JsonObj);
                return Resp;
            });
        }
        public Task<Systemgadgets> GetSystemGadgetsDataById(long GadgetId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SetupRepository.GetSystemGadgetsDataById(GadgetId);
                return Resp;
            });
        }
        #endregion

        #region Tenant Cards
        public Task<IEnumerable<SystemTenantsCardData>> GetSystemTenantCardData(long TenantId,int Offset, int Count)
        {
            return Task.Run(() =>
            {
                var Resp = db.SetupRepository.GetSystemTenantCardData(TenantId,Offset, Count);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterSystemTenantCards(string? JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.SetupRepository.RegisterSystemTenantCards(JsonObj);
                return Resp;
            });
        }
        public Task<SystemTenantCard> GetSystemTenantCardDataById(long CardId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SetupRepository.GetSystemTenantCardDataById(CardId);
                return Resp;
            });
        }
        //public Task<Genericmodel> GetSystemTenantCardById(long Tenantcardid)
        //{
        //    return Task.Run(() =>
        //    {
        //        var Resp = db.SetupRepository.GetSystemTenantCardById(Tenantcardid);
        //        return Resp;
        //    });
        //}

        public Task<Genericmodel> Resendcustomercardpin(long Tenantcardid)
        {
            return Task.Run(() =>
            {
                var Resp = db.SetupRepository.GetSystemTenantCardById(Tenantcardid);
                if (Resp.RespStatus == 0)
                {
                    //send Card Assignment Email
                    var commtempdata = db.SettingsRepository.Getsystemcommunicationtemplatedatabyname(true, "Customercardassignment");
                    if (commtempdata != null)
                    {
                        var Settings = db.SettingsRepository.Getsystemtenantaccountbytenantid(Convert.ToInt32(Resp.Data7));
                        StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                        StrBodyEmail.Replace("@CompanyLogo", Settings.TenantLogo);
                        StrBodyEmail.Replace("@CompanyName", Settings.Tenantname);
                        StrBodyEmail.Replace("@CompanyEmail", Settings.TenantEmail);
                        StrBodyEmail.Replace("@Fullname", Resp.Data1);
                        StrBodyEmail.Replace("@Cardmask", Resp.Data3);
                        StrBodyEmail.Replace("@Cardpin", sec.Decrypt(Resp.Data4, Resp.Data5));
                        StrBodyEmail.Replace("@Cardcode", Resp.Data6);
                        StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                        string message = StrBodyEmail.ToString();
                        //log Email Messages
                        EmailLogs Logs = new EmailLogs
                        {
                            EmailLogId = 0,
                            TenantId = Convert.ToInt32(Resp.Data7),
                            EmailAddress = Resp.Data2,
                            EmailSubject = commtempdata.Templatesubject,
                            EmailMessage = message,
                            IsEmailSent = false,
                            DateTimeSent = DateTime.Now,
                            Datecreated = DateTime.Now,
                        };
                        var resp = db.SecurityRepository.LogEmailMessage(JsonConvert.SerializeObject(Logs));
                        bool data = emlsnd.UttambsolutionssendemailAsync(Resp.Data2, commtempdata.Templatesubject, message, true, Settings.EmailServer, Settings.EmailAddress, Settings.EmailPassword);
                        if (data)
                        {
                            Resp.RespStatus = 0;
                            Resp.RespMessage = "Email Sent";
                        }
                        else
                        {
                            Resp.RespStatus = 1;
                            Resp.RespMessage = "Email not Sent";
                        }
                    }
                    else
                    {
                        Resp.RespStatus = 1;
                        Resp.RespMessage = "Template not found!";
                    }
                }
                else
                {
                    Resp.RespStatus = 1;
                    Resp.RespMessage = "Card Not Found";
                }
                return Resp;
            });
        }


        public Task<Genericmodel> Authenticatecustomercard(string CardCode,long CardPin)
        {
            return Task.Run(() =>
            {
                var Resp = db.SetupRepository.Getcustomercardbycardcode(CardCode);
                if (Resp.RespStatus == 0)
                {
                    Encryptdecrypt sec = new Encryptdecrypt();
                    string descpass = sec.Decrypt(Resp.Data1, Resp.Data2);
                    if (CardPin == Convert.ToInt32(descpass))
                    {
                        Resp.RespStatus = 0;
                        Resp.RespMessage = "Authorized";
                    }
                    else
                    {
                        Resp.RespStatus = 1;
                        Resp.RespMessage = "Incorrect Pin!";
                    }
                }
                else
                {
                    Resp.RespStatus = Resp.RespStatus;
                    Resp.RespMessage = Resp.RespMessage;
                }
                return Resp;
            });
        }


        #endregion

        #endregion

        #region Loyalty Formula
        public Task<LoyaltyFormulaandFormulaRules> GetSystemLoyaltyFormulaandFormulaRulesData(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.GetSystemLoyaltyFormulaandFormulaRulesData(TenantId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registerformulaandrules(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.Registerformulaandrules(JsonObj);
                return Resp;
            });
        }
        public Task<SystemFormulaData> GetSystemLoyaltyFormulaDataById(long FormulaId)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.GetSystemLoyaltyFormulaDataById(FormulaId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registerformulaeditdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.Registerformulaeditdata(JsonObj);
                return Resp;
            });
        }
        public Task<SystemFormulaRuleData> GetSystemLoyaltyFormularuleDataById(long FormulaRuleId)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.GetSystemLoyaltyFormularuleDataById(FormulaRuleId);
                return Resp;
            });
        }
        public Task<Genericmodel> RegisterformulaRuleeditdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.RegisterformulaRuleeditdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Loyalty Schemes
        public Task<LoyaltySchemeandSchemeRules> GetSystemLoyaltySchemeandSchemeRulesData(long TenantId)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.GetSystemLoyaltySchemeandSchemeRulesData(TenantId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registerschemeandrules(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.Registerschemeandrules(JsonObj);
                return Resp;
            });
        }
        public Task<SystemLoyaltyScheme> GetSystemLoyaltyschemeDataById(long SchemeId)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.GetSystemLoyaltyschemeDataById(SchemeId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registerschemeeditdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.Registerschemeeditdata(JsonObj);
                return Resp;
            });
        }
        public Task<SystemSchemeRuleResultData> GetSystemLoyaltyschemeRuleDataById(long LSchemeRuleId)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.GetSystemLoyaltyschemeRuleDataById(LSchemeRuleId);
                return Resp;
            });
        }
        public Task<Genericmodel> Registerschemeruleeditdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.LoyaltyRepository.Registerschemeruleeditdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Stations Related Data Products,Staffs etc
        public Task<SystemStationRelatedData> GetSystemStationRelatedData(long StationId)
        {
            return Task.Run(() =>
            {
                var Resp = db.SetupRepository.GetSystemStationRelatedData(StationId);
                return Resp;
            });
        }
        #endregion

        #region Delete,Deactivate System Columns
        public Task<Genericmodel> DeactivateorDeleteTableColumnData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.GeneralRepository.DeactivateorDeleteTableColumnData(obj);
                return Resp;
            });
        }
        public Task<Genericmodel> RemoveTableColumnData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.GeneralRepository.RemoveTableColumnData(obj);
                return Resp;
            });
        }
        public Task<Genericmodel> DefaultThisTableColumnData(string obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.GeneralRepository.DefaultThisTableColumnData(obj);
                return Resp;
            });
        }
        #endregion

        #region Validate Customer Driver
        public Task<Genericmodel> ValidateSystemCustomerorDriver(CustomerDriverRequest obj)
        {
            return Task.Run(async () =>
            {
                Genericmodel resp = new Genericmodel();
                if (obj.DriverCustomer == "Customer")
                {
                    string encpass = sec.Encrypt(obj.SecretCode, obj.SecretCode);
                    resp = db.CustomerRepository.ValidateSystemCustomer(obj.CustomerId, encpass);
                }
                else
                {
                    string encpass = sec.Encrypt(obj.SecretCode, obj.SecretCode);
                    resp = db.CustomerRepository.ValidateSystemCustomeremployee(obj.AccountId, encpass);
                }
                return resp;
            });
        }
        #endregion

        #region System Dropdowns
        public Task<IEnumerable<ListModel>> GetListModel(ListModelType listType)
        {
            return Task.Run(() =>
            {
                return db.GeneralRepository.GetListModel(listType);
            });
        }
        public Task<IEnumerable<ListModel>> GetListModelById(ListModelType listType, long Id)
        {
            return Task.Run(() =>
            {
                return db.GeneralRepository.GetListModelbycode(listType, Id);
            });
        }
        public Task<IEnumerable<ListModel>> GetListModelByIdAndSearchParam(ListModelType listType, long Id,string SearchParam)
        {
            return Task.Run(() =>
            {
                return db.GeneralRepository.GetListModelByIdAndSearchParam(listType, Id, SearchParam);
            });
        }
        public Task<IEnumerable<ListModel>> GetListModelByIdandTenantId(ListModelType listType, long TenantId, long Id)
        {
            return Task.Run(() =>
            {
                return db.GeneralRepository.GetListModelByIdandTenantId(listType, TenantId, Id);
            });
        }
        #endregion

        #region System Reports Data
        public Task<SalesTransactionsDetailsData> GetSalesTransactionsReportData(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.GetSalesTransactionsReportData(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Postpaid CustomerStatement Data
        public Task<CustomerPostpaidStatementDataReportData> GetCustomerPostpaidStatementReportData(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.GetCustomerPostpaidStatementReportData(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Customer Payment Data
        public Task<CustomerPaymentDataReport> GetCustomerPaymentReportData(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.GetCustomerPaymentReportData(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Prepaid Statement Data
        public Task<CustomerPrepaidStatementReportData> GetCustomerPrepaidStatementReportData(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.GetCustomerPrepaidStatementReportData(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Customer Topup Data
        public Task<CustomerTopupDataReport> GetCustomerTopupReportData(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.GetCustomerTopupReportData(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Customer Cumulative Points Data
        public Task<CustomerCumulativeDataReport> GetCustomerCumulativeReportData(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.GetCustomerCumulativeReportData(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Point Statement Data
        public Task<CustomerPostpaidStatementDataReportData> GetCustomerPointStatementReportData(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.GetCustomerPointStatementReportData(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Point Award Data
        public Task<CustomerPointAwardReport> GetCustomerPointAwardReportData(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.GetCustomerPointAwardReportData(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region System Customer Point Redeem Data
        public Task<CustomerPointRedeemReport> GetCustomerPointRedeemReportData(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.GetCustomerPointRedeemReportData(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Station Shift  Summary

        #region Shift Pump Reading
        public Task<ShiftPumpReadingReport> Generateshiftpumpreadingreportdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Generateshiftpumpreadingreportdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Tank Reading
        public Task<ShiftTankReadingDetails> Generateshifttankreadingreportdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Generateshifttankreadingreportdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Lube Lpg Reading
        public Task<ShiftLpgLubeReadingDetails> Generateshiftlubelpgreadingreportdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Generateshiftlubelpgreadingreportdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Expenses Reading
        public Task<ShiftExpensesDetails> Generateshiftexpensesreadingreportdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Generateshiftexpensesreadingreportdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Credit Sales Reading
        public Task<ShiftCreditSalesDetails> Generateshiftcreditsalereadingreportdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Generateshiftcreditsalereadingreportdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Cash Drops Reading
        public Task<ShiftCashDropsDetails> Generateshiftcashdropreadingreportdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Generateshiftcashdropreadingreportdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Purchases Reading
        public Task<ShiftpurchasesReadingDetails> Generateshiftpurchasereadingreportdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Generateshiftpurchasereadingreportdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Reading
        public Task<StationShiftDetailsData> Generatestationshiftreadingreportdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Generatestationshiftreadingreportdata(JsonObj);
                return Resp;
            });
        }
        #endregion

        #region Shift Summary Reading
        public Task<StationShiftSummaryDetailsData> Generatestationshiftsummaryreadingreportdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Generatestationshiftsummaryreadingreportdata(JsonObj);
                return Resp;
            });
        }
        #endregion
        #region Shift Customer Statement Reading
        public Task<ShiftCustomerStatementData> Generatestationshiftcustomerstatementreportdata(string JsonObj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ReportManagementRepository.Generatestationshiftcustomerstatementreportdata(JsonObj);
                return Resp;
            });
        }
        #endregion
        #endregion
    }
}