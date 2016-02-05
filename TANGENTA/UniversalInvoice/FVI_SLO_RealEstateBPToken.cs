#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalInvoice
{
    public class FVI_SLO_RealEstateBPToken
    {

            TemplateToken tBuildingNumber = null;
            TemplateToken tBuildingSectionNumber = null;
            TemplateToken tCommunity = null;
            TemplateToken tCadastralNumber = null;
            TemplateToken tValidityDate;
            TemplateToken tClosingTag = null;
            TemplateToken tSoftwareSupplier_TaxNumber = null;
            TemplateToken tPremiseType = null;

            public List<TemplateToken> list = new List<TemplateToken>();

            public FVI_SLO_RealEstateBPToken(ltext token_prefix,
                                        int _BuildingNumber,
                                        int _BuildingSectionNumber,
                                        string _Community,
                                        int _CadastralNumber,
                                        DateTime _ValidityDate,
                                        string _ClosingTag,
                                        string _SoftwareSupplier_TaxNumber,
                                        string _PremiseType)
            {
                tBuildingNumber = new TemplateToken(token_prefix, new string[] { "BuildingNumber", "ŠtevilkaStavbe" }, _BuildingNumber,null);
                tBuildingSectionNumber = new TemplateToken(token_prefix, new string[] { "BuildingSectionNumber", "ŠtevilkaDelaStavbe" }, _BuildingSectionNumber,null);
                tCommunity = new TemplateToken(token_prefix, new string[] { "Community", "Naselje" }, _Community,null);
                tCadastralNumber = new TemplateToken(token_prefix, new string[] { "CadastralNumber", "ŠtevilkaKatastrskeObčine" }, _CadastralNumber,null);
                tValidityDate = new TemplateToken(token_prefix, new string[] { "ValidityDate", "VeljavnostPodatkovDo" }, _ValidityDate,"YYYY-MM-DD");
                tClosingTag = new TemplateToken(token_prefix, new string[] { "ClosingTag", "ZaprtjePoslovnegaProstora" }, _ClosingTag,null);
                tSoftwareSupplier_TaxNumber = new TemplateToken(token_prefix, new string[] { "SoftwareSupplier_TaxNumber", "DavčnaŠtevilkaDobaviteljaProgramskeOpreme" }, _SoftwareSupplier_TaxNumber,null);
                tPremiseType = new TemplateToken(token_prefix, new string[] { "PremiseType", "VrstaPoslovnegaProstora" }, _PremiseType,null);

                list.Add(tBuildingNumber);
                list.Add(tBuildingSectionNumber);
                list.Add(tCommunity);
                list.Add(tCadastralNumber);
                list.Add(tValidityDate);
                list.Add(tClosingTag);
                list.Add(tSoftwareSupplier_TaxNumber);
                list.Add(tPremiseType);
            }
    }
}
