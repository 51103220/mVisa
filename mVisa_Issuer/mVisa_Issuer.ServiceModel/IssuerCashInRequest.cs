﻿using Common.DTOs.Request;
using ServiceStack;
using System.Runtime.Serialization;
using static Common.Constants;

namespace mVisa_Issuer.ServiceModel
{
    [Route(ISSUER.CASH_IN_REQUEST_URL, POST)]
    [DataContract]
    public class IssuerCashInRequest : CashInRequestDto, IReturn<IssuerCashInResponse>
    {
    }

    public class IssuerCashInResponse
    {
        public string Result { get; set; }
    }
}