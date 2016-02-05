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
    public class FVI_SLO_RealEstateBP
    {
        public int BuildingNumber = 0;
        public int BuildingSectionNumber = 0;
        public string Community = null;
        public int CadastralNumber = 0;
        public DateTime ValidityDate;
        public string ClosingTag = null;
        public string SoftwareSupplier_TaxNumber = null;
        public string PremiseType = null;

        public FVI_SLO_RealEstateBPToken token = null;

        public FVI_SLO_RealEstateBP(ltext token_prefix,
                                   int _BuildingNumber,
                                   int _BuildingSectionNumber,
                                   string _Community,
                                   int _CadastralNumber,
                                   DateTime _ValidityDate,
                                   string _ClosingTag,
                                   string _SoftwareSupplier_TaxNumber,
                                   string _PremiseType)
        {
            BuildingNumber = _BuildingNumber;
            BuildingSectionNumber = _BuildingSectionNumber;
            Community = _Community;
            CadastralNumber = _CadastralNumber;
            ValidityDate = _ValidityDate;
            ClosingTag = _ClosingTag;
            SoftwareSupplier_TaxNumber = _SoftwareSupplier_TaxNumber;
            PremiseType = _PremiseType;
            token = new FVI_SLO_RealEstateBPToken(token_prefix,
                                                    BuildingNumber,
                                                    BuildingSectionNumber,
                                                    Community,
                                                    CadastralNumber,
                                                    ValidityDate,
                                                    ClosingTag,
                                                    SoftwareSupplier_TaxNumber,
                                                    PremiseType);
        }
    }
}
