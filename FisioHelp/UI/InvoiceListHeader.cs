using System.Windows.Forms;
using LinqToDB;
using System.Linq;
namespace FisioHelp.UI
{
  using DataModels;

  public partial class InvoiceListHeader : UserControl
  {
	  public DataModels.ProformaInvoice ProformaInvoice { get; set; }
    private bool _loaded = false;
    public Customer Customer;

    public InvoiceListHeader()
    {
      InitializeComponent();

    }
  }
}
