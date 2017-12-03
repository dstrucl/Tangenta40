#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using LanguageControl;

namespace FiscalVerificationOfInvoices_SLO
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_FVI_AnswerToQuestion53 = new ltext(new string[] { "", @"
        Vprašanje 51: Kaj je postopek potrjevanja računov z uporabo elektronske naprave za izdajo računov? (16. 7. 2015, 21. 8. 2015) 

     Elektronska naprava bo ustvarila elektronsko podpisano XML datoteko s podatki o izdanem računu
     in jo poslala na FURS.Informacijski sistem FURS bo preveril poslane podatke 
     in poslal elektronski napravi posebno enkratno identifikacijsko oznako računa (EOR),
     ki se bo izpisala na računu.S takšnim postopkom FURS pred izdajo potrdi izdani račun. 

     Postopek potrjevanja računov je sestavljen iz treh faz: 
      - pošiljanja podatkov o računu davčnemu organu,  
      - obdelave podatkov o računu in dodelitve enkratne identifikacijske oznake računa v informacijskem sistemu davčnega organa in  - pošiljanja enkratne identifikacijske oznake računa zavezancu. 
    ____________________________
     11 4. člen ZDavPR 


      Za dodelitev enkratne identifikacijske oznake računa bosta morala biti izpolnjena dva pogoja:
          - posredovani bodo morali biti vsi predpisani podatki o računu in 
          - podatki o računu bodo morali biti podpisani z namenskim digitalnim potrdilom.

      Če bosta oba pogoja izpolnjena, bo davčni organ podatkom o računu dodelil enkratno identifikacijsko oznako (12)
      in jo prek vzpostavljene elektronske povezave poslal zavezancu.
      Za enkratno identifikacijsko oznako računa se uporablja kratica EOR.

      Opisana izmenjava podatkov bo izvedena v zelo kratkem času in bo omogočala izdajo računa,
      na katerem bo navedena enkratna identifikacijska oznaka računa, ki dokazuje,
      da je račun potrjen oziroma evidentiran pri davčnemu organu.

      Če kateri od pogojev za dodelitev enkratne identifikacijske oznake računa ne bo izpolnjen,
      bo davčni organ zavezancu prek vzpostavljene elektronske povezave poslal sporočilo 
      o zavrnitvi dodelitve enkratne identifikacijske oznake računa.V sporočilu bo navedena napaka,
      do katere je prišlo pri obdelavi podatkov. 
      V takšnem primeru bo zavezanec izdal račun brez enkratne identifikacijske oznake računa in 
      poslal podatke o izdanem računu davčnemu organu ob izpolnjevanju predpisanih pogojev (odpravi napak)
      v roku dveh delovnih dni od dneva izdaje računa.
      Zavezanec bo moral torej posredovati pravilne podatke o računih do konca drugega delovnega dne, 
      ki bo sledi delovnemu dnevu, v katerem je prišlo do izdaje računa.
      Davčni organ bo računu naknadno dodelil enkratno identifikacijsko oznako računa in 
      jo poslal zavezancu.Račun bo pri davčnemu organu potrjen, 
      ko bo zavezanec prejel sporočilo z enkratno identifikacijsko oznako računa.
      Zavezanec bo moral hraniti podatek o enkratni identifikacijski oznaki računa 
      skupaj s kopijo izdanega računa skladno z ZDavP-2.  


      Vsebina in obliko sporočil z obveznimi podatki o računu ter protokole in
      varnostne mehanizme za izmenjavo podatkov, model uporabe, pri katerem se za pošiljanje in
      podpisovanje sporočil uporablja centralni informacijski sistem zavezanca, model uporabe,
      pri katerem se pošiljanje in podpisovanje elektronskih sporočil izvaja posamično na elektronskih napravah za izdajo računov,
      standardna sporočila o napakah in protokole postopkov v primeru napak, so predpisana s Pravilnikom o izvajanju ZDavPR.." });



        public static ltext s_GoToSalesBookInvoice = new ltext(new string[] { "Write into SalesBookInvoice", "Vpišite v vezano knjgo računov" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\FormFURSCommunicationERRORhandler.cs

        public static ltext s_InternetConnectionISOK_maybe_FURS_server_is_not_online = new ltext(new string[]{"Your computer has Internet Connection."
                                                                                                 + "\r\nIf there is no communication with DURS please call them to check if their server is online!",
                                                                                                 "Vaš računalnik ima povezavo v svetovni splet (\"internet\")."
                                                                                                 + "\r\nČe še vedno ne uspete poslati podatke na DURS, preverite na DURS-u, če njihov strežnik za potrjevanje računov deluje."});   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\FormFURSCommunicationERRORhandler.cs

        public static ltext s_NoInternetConnection = new ltext(new string[]{"You have no Internet Connection!"
                                                                + "\r\nPlease check your cable connection or Wifi Connection!"
                                                            , "Nimate povezave na svetovni splet (\"Internet\")!"
                                                            + "\r\nČe ste na brezžični povezavi preverite ali le ta deluje, sicer pa preverite ali je mrežni kabel sploh priključen v vaš rečunalnik."
                                                            });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\FormFURSCommunicationERRORhandler.cs

        public static ltext s_CheckInternetConnection = new ltext(new string[] { "Check Internet Connection", "Preveri povezavo na svetovni splet" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\FormFURSCommunicationERRORhandler.cs

        public static ltext s_InvoiceNotSentOK = new ltext(new string[] { "Invoice was not sent to DURS !", "Račun ni bil uspešno poslan ali potrjen na davčni upravi" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\FormFURSCommunicationERRORhandler.cs

        public static ltext s_InstructionToTryToSendFURSDataAgain = new ltext(new string[]{"Data was not send to DURS!\r\nYou can:"
                                                                              + "\r\n\r\n   1. click \"Send invoice data to DURS again\" button after you have checked your internet connection ! or"
                                                                              + "\r\n\r\n   2. click \"Write into SalesBookInvoice\" button to write invoice data into Sales Book Invoice.",
                                                                              "Račun ni bil supešno poslan davčni upravi!\r\n\r\nIzberete lahko:"
                                                                              + "\r\n\r\n   1. kliknite gumb \"Ponovno pošlji račun davčni upravi\" v kolikor ste preverili, da imate povezavo na svetovni splet ali pa"
                                                                              + "\r\n\r\n   2. kliknite gumb \"Vpišite v vezano knjigo računov\" kjer boste potem morali račun vpisati v vezano knjigo računov,"
                                                                              + "r\n      le to pa boste lahko poslali davčni upravi, ko bo zopet povezava z davčno upravo delovala."});   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\FormFURSCommunicationERRORhandler.cs

        public static ltext s_TryToSendFURSDataAgain = new ltext(new string[] { "Send invoice data to DURS again", "Ponovno pošlji račun davčni upravi" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\FormFURSCommunicationERRORhandler.cs

        public static ltext s_Error = new ltext(new string[]{"Error",
                                         "Napaka"});   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\FormFURSCommunicationERRORhandler.cs

        public static ltext s_SignUpBussinesPremisse = new ltext(new string[] { "Sign up your bussines premise at fiscal authorites", "Prijava poslovnega prostora pri davčni upravi" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_BussinesPremisse.cs

        public static ltext s_Furs_Test_Environment = new ltext(new string[] { "FURS Test environment", "FURS TESTNO okolje !" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_BussinesPremisse.cs

        public static ltext ss_Exit = new ltext(new string[] { "Exit", "	Izhod" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_BussinesPremisse.cs

        public static ltext s_Warning = new ltext(new string[]{"Warning",
                                           "Opozorilo"});   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_BussinesPremisse.cs

        public static ltext s_SalesBookInvoice_SetNumber_GraterThanAllSetsDefinedInSettings = new ltext(new string[] { "Set number is greater the number of all sets.Please ask tehnical support to change settings.", "Vnesli ste številko seta iz vezane knjige računov, ki je večja od števila vseh setov.\r\nPokličite tehnično podporo, da spremeni nastavite, ali pa vnesite pravo številko." });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_EnterData_to_SalesBookInvoice.cs

        public static ltext s_SalesBookInvoice_SetNumber_Not_OK = new ltext(new string[] { "SalesBookInvoice set number is not OK!", "Številka seta iz vezane knjige računov ni ustrezna!" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_EnterData_to_SalesBookInvoice.cs

        public static ltext sSalesBookInvoice_SerialNumber_does_not_match_patern = new ltext(new string[]{"SalesBook serial number does not match patern ####-####### where '#' means number 0-9!"
                                                                                              + "\r\nPlease write serial number in proper format or ask technical support to change Regular Expression pattern in Settings."
                                                                                              + "\r\nIf you press Yes, serial number with wrong format will be accepted, otherwise press No ?",
                                                                                              "Serijska številka vezane knjige računov ne ustreza formatu ####-####### (štiri številke, minus nato še sedem številk)!"
                                                                                              + "\r\nVpišite serijsko številko v navedenem formatu ali pa naj vam tehnična podpora spremeni format za serijsko številko v nastavitvah."
                                                                                             + "\r\nV kolikor izberete Da (Yes) bo serijska številka sprejeta ne glede na format, če kliknete Ne(No) nadaljujete z vnosom?"});   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_EnterData_to_SalesBookInvoice.cs

        public static ltext s_LastSetNumberIsMoreThan_MAX_SalesBookInvoice_SetNumber = new ltext(new string[] { "SetNumber in SalesBookInvoice exceeded maximum set number which is set to:", "Številka seta v vezani knjigi računov presega zadnjo številko seta ki je:" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_EnterData_to_SalesBookInvoice.cs

        public static ltext s_TakeNewSalesBookInvoiceAndWriteItsSerialNumberFirst = new ltext(new string[] { "Use new SalesBookInvoice and enter it's serial number first!", "Vzemite novo vezano knjigo računov in vpišite najprej njeno serijsko številko!" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_EnterData_to_SalesBookInvoice.cs

        public static ltext s_SalesBookInvoice = new ltext(new string[] { "Sales book invoice", "Vezana knjiga računov" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_EnterData_to_SalesBookInvoice.cs

        public static ltext s_FVI_Edit_DocType_Settings = new ltext(new string[] { "Edit settings for Fiscal verification of invoice types", "Urejanje nastavitev davčnega potrjevanja glede na način plačila" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_Main.cs

        public static ltext s_FVI_for_cash_payment = new ltext(new string[] { "Fiscal verification of invoices for cash payment", "Davčno potrjevanje računov za plačila z gotovino" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_Main.cs

        public static ltext s_FVI_for_card_payment = new ltext(new string[] { "Fiscal verification of invoices for card payment", "Davčno potrjevanje računov za plačila s kartico" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_Main.cs

        public static ltext s_FVI_for_payment_on_bankaccount = new ltext(new string[] { "Fiscal verification of invoices for payment on bank account", "Davčno potrjevanje računov za plačila na bančni račun" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_Main.cs

        public static ltext s_FURS_WWW_btn_Check_invoice = new ltext(new string[] { "FURS WWW for checking invoices", "Domača stran davčne uprave za preverjanje računov in ostalo" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_Main.cs

        public static ltext s_FVI_Check = new ltext(new string[] { "Fiscal Verification of invoices", "Davčno potrjevanje računov" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_Main.cs

        public static ltext s_SalesBookInvoice_UnsentMsg = new ltext(new string[] { "Send unsent invoices from SalesBookInvoice in ten days after invoice issue date!", "Pošljite neposlane račune iz vezane knjige računov najkasneje v desetih dneh od izstavitve računa!" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_Invoice_UnsentMsg = new ltext(new string[] { "Send unsent invoices in two working days after invoice issue date!", "Pošljite davčno nepotrjene račune najkasneje v dveh delovnih dneh od izstavitve računa!" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_SendtoDurs = new ltext(new string[] { "Send", "Pošlji" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_Issuer_FirstName = new ltext(new string[] { "Issuer first name", "Ime blagajnika" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_Issuer_LastName = new ltext(new string[] { "Issuer last name", "Priimek blagajnika" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_FinancialYear = new ltext(new string[] { "Financial Year", "Poslovno leto" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_InvoiceNumber = new ltext(new string[] { "Invoice Number in Financial Year", "Številka računa v poslovnem letu" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_IssueDate = new ltext(new string[] { "Issue date", "Čas izdaje" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_GrossSum = new ltext(new string[] { "Total", "Znesek računa" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_TaxSum = new ltext(new string[] { "Tax", "Davek" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_NetSum = new ltext(new string[] { "Net sum", "Neto cena" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_SalesBook_SerialNumber = new ltext(new string[] { "SalesBookInvoice Serial Number", "Serijska številka vezane knjige računov" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_SalesBook_SetNumber = new ltext(new string[] { "SalesBookInvoice Set Number", "Številka seta vezane knjige računov" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_SalesBookInvoice_Send.cs

        public static ltext s_Furs_Environment = new ltext(new string[] { "FURS environment", "FURS okolje" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Form_Settings.cs

        public static ltext s_CertificateIsEqualToBuiltInTestCertificate = new ltext(new string[] { "Certificate is equal with built in test certificate!", "Certfikat se ujema z vgrajenim testnim certifikatom!" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\TestCertificate.cs

        public static ltext s_CertificateNotEqualToBuiltInTestCertificate = new ltext(new string[] { "Certificate is not equal with built in test certificate!", "Certfikat se ne ujema z vgrajenim testnim certifikatom!" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\TestCertificate.cs

        public static ltext ss_Length = new ltext(new string[] { "Length", "Dolžina	" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\TestCertificate.cs

        public static ltext sFileDoesNotExist = new ltext(new string[]{"Warning! File does not exist or is not defined!",
                                                          "Opozorilo! Datoteka ne obstaja ali pa še ni določena!"});   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\Thread_FVI.cs

        public static ltext s_lbl_FURS_BussinesData = new ltext(new string[] { "FURS bussines data", "FURS poslovni podatki" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_fursBuildingNumber = new ltext(new string[] { "Building number", "Številka stavbe" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_BuildingSectionNumber = new ltext(new string[] { "Building section number", "Številka dela stavbe" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_Community = new ltext(new string[] { "Community", "Naselje" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_CadastralNumber = new ltext(new string[] { "Cadastral number", "Katastrska številka" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_ValidityDate = new ltext(new string[] { "Validity Date", "Datum veljavnosti" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_SoftwareSupplier_TaxNumber = new ltext(new string[] { "Software supplier Tax ID", "Davčna številka dobavitelja programske opreme" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_PremiseType = new ltext(new string[] { "Premise type", "Vrsta Nepremičnine" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_MyOrganisation_TaxID = new ltext(new string[] { "My organisation Tax ID", "Davčna številka moje organizacije" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_BussinesPremiseID = new ltext(new string[] { "Bussines Premise ID", "Oznaka poslovnega prostora" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_InvoiceAuthor_TaxID = new ltext(new string[] { "Davčna številka izdajatelja računa", "Davčna številka izdajatelja računa" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_btn_ImportFromDataBase = new ltext(new string[] { "Import from Data Base", "Uvozi iz baze podatkov" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_StreetName = new ltext(new string[] { "Adress", "Naslov" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_Street_Number = new ltext(new string[] { "House number", "Hišna št." });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_Post = new ltext(new string[] { "Post number", "Poštna št." });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_lbl_City = new ltext(new string[] { "City", "Kraj" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_SelectCertificate = new ltext(new string[] { "Select certificate", "Izberite Certifikat" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_environment_settings.cs

        public static ltext s_SignUpYourBussinesBremise = new ltext(new string[] { "Sign up your bussines premise at fiscal authorites", "Registrirajte poslovni prostor pri davčni upravi!\r\n" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FVI_SLO.cs

        public static ltext s_FVI_SLO_Error = new ltext(new string[] { "Error in communication with Tax Administration ", "Napaka v komunikaciji z davčno upravo" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FVI_SLO.cs

        public static ltext s_DoYouRealyWantToResetSettingsFor_FiscalVerificationOfInvoices = new ltext(new string[] { "Do you realy want to reset Settings for fiscal verification of invoices", "Ste prepričani, da zares želite ponastaviti nastavitve za davčno potrjevanje računov na začetno programsko vrednost ?" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FVI_SLO.cs

        public static ltext s_SendInvoiceLater = new ltext(new string[] { "Send Invoice later in 48 hours", "Pošlji račun nakasneje v 48 urah" });   // referenced in C:\Tangenta40\SLO_FISCAL\FiscalVerificationOfInvoices_SLO\usrc_FURS_BussinesPremiseData.cs

        public static ltext s_Send = new ltext(new string[] { "Send", "Pošlji" });
    }
}
