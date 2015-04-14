
namespace Nacha.Core
{
    public class BrokerBankAccount : Bank
    {
	    private readonly string _bankName;

	    public BrokerBankAccount(string a_BankName, string a_RoutingNumber)
	    {
		    _bankName = a_BankName.Trim();
		    routingNumber = a_RoutingNumber.Trim();
	    }

	    public string GetBankName()
	    {
		    return _bankName.ToUpper();
	    }

	    public string GetRoutingNumber()
	    {
		    return routingNumber;
	    }

    }
}
