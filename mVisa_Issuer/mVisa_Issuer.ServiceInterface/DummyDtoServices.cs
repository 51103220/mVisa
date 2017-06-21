using Common.DTOs.Request;
using System;
using Utils;

namespace mVisa_Issuer.ServiceInterface
{
    public static class DummyDtoServices
    {
        public static CashInRequestDto NewCashInRequestDto()
        {
            return new CashInRequestDto
            {
                AcquirerCountryCode = 643,
                AcquiringBin = 400171,
                Amount = 1200,
                BusinessApplicationId = "CI",
                CardAcceptor = new CardAcceptor
                {
                    Name = "Acceptor 1",
                    Address = new Address
                    {
                        City = "Bangalore",
                        Country = "IND"
                    },
                    IdCode = "ID-Code123"
                },
                LocalTransactionDateTime = DateTime.Now.ToMVisaDateString(),
                MerchantCategoryCode = 4829,
                RecipientPrimaryAccountNumber = "4761360055652118",
                RetrievalReferenceNumber = "430000367618",
                SenderAccountNumber = "4957030420210496",
                SenderName = "Mohammed Qasim",
                SenderReference = "1234",
                SystemsTraceAuditNumber = 313042,
                TransactionCurrencyCode = "INR",
                TransactionIdentifier = "381228649430015"
            };
        }

        public static CashOutRequestDto NewCashOutRequestDto()
        {
            return new CashOutRequestDto
            {
                AcquirerCountryCode = 643,
                AcquiringBin = 400171,
                Amount = 124.05,
                BusinessApplicationId = "CO",
                CardAcceptor = new CardAcceptor
                {
                    Name = "mVisa cashout",
                    Address = new Address
                    {
                        City = "mVisa cashout",
                        Country = "IND"
                    },
                    IdCode = "CA-IDCode-77765"
                },
                LocalTransactionDateTime = DateTime.Now.ToMVisaDateString(),
                MerchantCategoryCode = 6012,
                RecipientPrimaryAccountNumber = "4123640062698797",
                RetrievalReferenceNumber = "412123412878",
                SenderAccountNumber = "456789123456",
                SenderName = "Mohammed Qasim",
                SenderReference = "REFNUM123",
                SystemsTraceAuditNumber = 567889,
                TransactionCurrencyCode = "USD",
                TransactionIdentifier = "381228649430015"
            };
        }

        public static MerchantPaymentRequestDto NewMerchantPaymentRequestDto()
        {
            return new MerchantPaymentRequestDto
            {
                AcquirerCountryCode = 356,
                AcquiringBin = 408972,
                Amount = 124.05,
                BusinessApplicationId = "MP",
                CardAcceptor = new CardAcceptor
                {
                    Name = "Visa Inc. USA-Foster City",
                    Address = new Address
                    {
                        City = "KOLKATA",
                        Country = "IND"
                    },
                    IdCode = "CA-IDCode-77765"
                },
                FeeProgramIndicator = "123",
                LocalTransactionDateTime = DateTime.Now.ToMVisaDateString(),
                PurchaseIdentifier = new PurchaseIdentifier
                {
                    ReferenceNumber = "REF_123456789123456789123",
                    Type = "1"
                },
                RecipientName = "Jasper",
                RecipientPrimaryAccountNumber = "4123640062698797",
                RetrievalReferenceNumber = "12770451035",
                SecondaryId = "123TEST",
                SenderAccountNumber = "4027290077881587",
                SenderName = "Jasper",
                SenderReference = "",
                SystemsTraceAuditNumber = 451035,
                TransactionCurrencyCode = "INR",
                TransactionIdentifier = "381228649430015"
            };
        }
    }
}
