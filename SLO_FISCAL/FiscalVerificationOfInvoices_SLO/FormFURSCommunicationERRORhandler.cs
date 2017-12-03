using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalVerificationOfInvoices_SLO
{


    //    Vprašanje 51: Kaj je postopek potrjevanja računov z uporabo elektronske naprave za izdajo računov? (16. 7. 2015, 21. 8. 2015) 

    // Elektronska naprava bo ustvarila elektronsko podpisano XML datoteko s podatki o izdanem računu
    // in jo poslala na FURS.Informacijski sistem FURS bo preveril poslane podatke 
    // in poslal elektronski napravi posebno enkratno identifikacijsko oznako računa (EOR),
    // ki se bo izpisala na računu.S takšnim postopkom FURS pred izdajo potrdi izdani račun. 

    // Postopek potrjevanja računov je sestavljen iz treh faz: 
    //  - pošiljanja podatkov o računu davčnemu organu,  
    //  - obdelave podatkov o računu in dodelitve enkratne identifikacijske oznake računa v informacijskem sistemu davčnega organa in  - pošiljanja enkratne identifikacijske oznake računa zavezancu. 
    //____________________________
    // 11 4. člen ZDavPR 


    //  Za dodelitev enkratne identifikacijske oznake računa bosta morala biti izpolnjena dva pogoja:
    //      - posredovani bodo morali biti vsi predpisani podatki o računu in 
    //      - podatki o računu bodo morali biti podpisani z namenskim digitalnim potrdilom.

    //  Če bosta oba pogoja izpolnjena, bo davčni organ podatkom o računu dodelil enkratno identifikacijsko oznako (12)
    //  in jo prek vzpostavljene elektronske povezave poslal zavezancu.
    //  Za enkratno identifikacijsko oznako računa se uporablja kratica EOR.

    //  Opisana izmenjava podatkov bo izvedena v zelo kratkem času in bo omogočala izdajo računa,
    //  na katerem bo navedena enkratna identifikacijska oznaka računa, ki dokazuje,
    //  da je račun potrjen oziroma evidentiran pri davčnemu organu.

    //  Če kateri od pogojev za dodelitev enkratne identifikacijske oznake računa ne bo izpolnjen,
    //  bo davčni organ zavezancu prek vzpostavljene elektronske povezave poslal sporočilo 
    //  o zavrnitvi dodelitve enkratne identifikacijske oznake računa.V sporočilu bo navedena napaka,
    //  do katere je prišlo pri obdelavi podatkov. 
    //  V takšnem primeru bo zavezanec izdal račun brez enkratne identifikacijske oznake računa in 
    //  poslal podatke o izdanem računu davčnemu organu ob izpolnjevanju predpisanih pogojev (odpravi napak)
    //  v roku dveh delovnih dni od dneva izdaje računa.
    //  Zavezanec bo moral torej posredovati pravilne podatke o računih do konca drugega delovnega dne, 
    //  ki bo sledi delovnemu dnevu, v katerem je prišlo do izdaje računa.
    //  Davčni organ bo računu naknadno dodelil enkratno identifikacijsko oznako računa in 
    //  jo poslal zavezancu.Račun bo pri davčnemu organu potrjen, 
    //  ko bo zavezanec prejel sporočilo z enkratno identifikacijsko oznako računa.
    //  Zavezanec bo moral hraniti podatek o enkratni identifikacijski oznaki računa 
    //  skupaj s kopijo izdanega računa skladno z ZDavP-2.  


    //  Vsebina in obliko sporočil z obveznimi podatki o računu ter protokole in
    //  varnostne mehanizme za izmenjavo podatkov, model uporabe, pri katerem se za pošiljanje in
    //  podpisovanje sporočil uporablja centralni informacijski sistem zavezanca, model uporabe,
    //  pri katerem se pošiljanje in podpisovanje elektronskih sporočil izvaja posamično na elektronskih napravah za izdajo računov,
    //  standardna sporočila o napakah in protokole postopkov v primeru napak, so predpisana s Pravilnikom o izvajanju ZDavPR..

    public partial class FormFURSCommunicationERRORhandler : Form
    {
        private string errorMessage;

        public FormFURSCommunicationERRORhandler()
        {
        }

        public FormFURSCommunicationERRORhandler(string errorMessage)
        {
            InitializeComponent();
            this.errorMessage = errorMessage;
            lng.s_CheckInternetConnection.Text(btn_CheckInternetConnection);
            lng.s_Error.Text(this.lbl_ErrorMessage,":"+errorMessage);
            lng.s_InvoiceNotSentOK.Text(this);
            lng.s_TryToSendFURSDataAgain.Text(this.btn_TryAagin);
            lng.s_GoToSalesBookInvoice.Text(this.btn_WriteInSalesBook);
            lng.s_InstructionToTryToSendFURSDataAgain.Text(this.lbl_Message);
            lng.s_SendInvoiceLater.Text(this.btn_SendLater);
        }

        private void btn_TryAagin_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Retry;
        }

        private void btn_WriteInSalesBook_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_CheckInternetConnection_Click(object sender, EventArgs e)
        {
            if (LogFile.LogFile.CheckForInternetConnection())
            {
                MessageBox.Show(lng.s_InternetConnectionISOK_maybe_FURS_server_is_not_online.s);
            }
            else
            {
                MessageBox.Show(lng.s_NoInternetConnection.s);
            }
        }

        private void btn_SendLater_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Ignore;
        }
    }
}
