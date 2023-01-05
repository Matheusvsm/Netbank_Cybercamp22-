CREATE OR REPLACE FUNCTION public.getfgtspaymentbystatus(
	"paramStatus" integer)
    RETURNS TABLE(
        "FGTSPaymentId" bigint, 
        "AccountId" bigint, 
        "TaxId" character varying, 
        "OperationId" bigint,
        "ContributorTaxId" character varying, 
        "PrincipalValue" numeric, 
        "CodeRevenue" character varying, 
        "Barcode" character varying, 
        "FGTSIdentifier" character varying, 
        "SocialConnectivityCode" bigint, 
        "SocialConnectivityDigit" integer,
        "PaymentDate" timestamp without time zone, 
        "RateValueType" bigint, 
        "Status" integer, 
        "Attempts" integer,
        "ExternalIdentifier" bigint, 
        "Description" character varying, 
        "Identifier" character varying, 
        "DeletionDate" timestamp without time zone, 
        "CreationDate" timestamp without time zone, 
        "UpdateDate" timestamp without time zone, 
        "CreationUserId" bigint, 
        "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
	   "FGTSPaymentId",
        "AccountId",
        "TaxId",
        "OperationId",
		"ContributorTaxId",
        "PrincipalValue",
        "CodeRevenue",
        "Barcode",
        "FGTSIdentifier",
        "SocialConnectivityCode",
        "SocialConnectivityDigit",
        "PaymentDate",
        "RateValueType",
		"Status",
        "Attempts",
		"ExternalIdentifier",
        "Description",
        "Identifier",
        "DeletionDate",
        "CreationDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId"
		
FROM public."FGTSPayment" 
WHERE "Status" = "paramStatus"  AND
	  	  "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getfgtspaymentbystatus(integer)
    OWNER TO "OSB";