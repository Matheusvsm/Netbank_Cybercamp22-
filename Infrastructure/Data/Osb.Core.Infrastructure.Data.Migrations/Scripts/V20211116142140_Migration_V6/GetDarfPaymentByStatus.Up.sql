CREATE OR REPLACE FUNCTION public.getdarfpaymentbystatus(
    "paramStatus" integer)
    RETURNS TABLE(
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
        "paramStatus" integer,
        "Attempts" integer,
        "ExternalIdentifier" bigint,
        "CreationDate" timestamp with time zone,
        "UpdateDate" timestamp with time zone,
        "CreationUserId" bigint,
        "UpdateUserId" bigint
        ) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT 
        "DARFPaymentId", 
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
        "Attempts",
        "ExternalIdentifier",
        "CreationDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."DARFPayment" 
WHERE "Status" = "paramStatus" 
    AND "DeletionDate" IS NULL;
$BODY$;
ALTER FUNCTION public.getdarfpaymentbystatus(integer)
    OWNER TO "OSB";