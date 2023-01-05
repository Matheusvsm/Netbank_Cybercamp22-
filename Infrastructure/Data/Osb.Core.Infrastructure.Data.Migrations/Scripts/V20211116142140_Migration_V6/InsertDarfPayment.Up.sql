CREATE OR REPLACE FUNCTION public.insertdarfpayment(
    "paramUserId" bigint,
    "paramAccountId" bigint,
    "paramOperationId" bigint,
    "paramTaxId" character varying,
    "paramDARFType" integer,
    "paramCalculationPeriod" character varying,
    "paramCodeRevenue" character varying,
    "paramContributorTaxId" character varying,
    "paramReferenceNumber" character varying,
    "paramDueDate" timestamp with time zone,
    "paramGrossRevenueValue" numeric,
    "paramGrossRevenuePercentage" character varying,
    "paramPrincipalValue" numeric,    
    "paramFineValue" numeric,
    "paramInterestValue" numeric,
    "paramPaymentDate" timestamp without time zone,
    "paramDescription" character varying,
    "paramIdentifier" character varying,
    "paramRateValueType" bigint,
    "paramStatus" integer
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."DARFPayment"
                    (                    
                    "AccountId",
                    "OperationId",
                    "TaxId",
                    "DARFType",
                    "CalculationPeriod",
                    "CodeRevenue",
                    "ContributorTaxId",
                    "ReferenceNumber",
                    "DueDate",
                    "GrossRevenueValue" ,
                    "GrossRevenuePercentage",
                    "PrincipalValue",    
                    "FineValue",
                    "InterestValue",
                    "PaymentDate",
                    "Description",
                    "Identifier",
                    "RateValueType",
                    "Status",                    
                    "CreationDate",
                    "UpdateDate",
                    "CreationUserId",
                    "UpdateUserId"
                     )
  VALUES (        
        "paramAccountId",
        "paramOperationId",
        "paramTaxId",
        "paramDARFType",
        "paramCalculationPeriod",
        "paramCodeRevenue",
        "paramContributorTaxId",
        "paramReferenceNumber",
        "paramDueDate",
        "paramGrossRevenueValue",
        "paramGrossRevenuePercentage",
        "paramPrincipalValue",    
        "paramFineValue",
        "paramInterestValue",
        "paramPaymentDate",
        "paramDescription",
        "paramIdentifier",
        "paramRateValueType",
        "paramStatus",
        NOW(),
        NOW(),
        "paramUserId",
        "paramUserId"
        )
$BODY$;
ALTER FUNCTION public.insertdarfpayment(bigint, bigint, bigint, character varying, integer, character varying, character varying, character varying, character varying, timestamp with time zone, numeric, character varying, numeric, numeric, numeric, timestamp without time zone,character varying, character varying, bigint, integer)
    OWNER TO "OSB";