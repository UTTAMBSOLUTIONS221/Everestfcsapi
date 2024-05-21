using DBL.Entities;
using DBL.Models;

namespace DBL.Repositories
{
    public interface ILoyaltyRepository
    {
        LoyaltyFormulaandFormulaRules GetSystemLoyaltyFormulaandFormulaRulesData(long TenantId);
        Genericmodel Registerformulaandrules(string JsonObjectdata);
        SystemFormulaData GetSystemLoyaltyFormulaDataById(long FormulaId);
        Genericmodel Registerformulaeditdata(string JsonObjectdata);
        SystemFormulaRuleData GetSystemLoyaltyFormularuleDataById(long FormulaRuleId);
        Genericmodel RegisterformulaRuleeditdata(string JsonObjectdata);

        LoyaltySchemeandSchemeRules GetSystemLoyaltySchemeandSchemeRulesData(long TenantId);
        Genericmodel Registerschemeandrules(string JsonObjectdata);

     
        SystemLoyaltyScheme GetSystemLoyaltyschemeDataById(long SchemeId);
        Genericmodel Registerschemeeditdata(string JsonObjectdata);
        SystemSchemeRuleResultData GetSystemLoyaltyschemeRuleDataById(long LSchemeRuleId);
        Genericmodel Registerschemeruleeditdata(string JsonObjectdata);
    }
}
