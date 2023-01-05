CREATE OR REPLACE FUNCTION public.getfgtspaymentbyidentifier(
	"paramIdentifier" character varying)
    RETURNS TABLE(
        "FGTSPaymentId" bigint, 
        "AccountId" bigint, 
        "TaxId" character varying,
        "ContributorTaxId" character varying, 
        "OperationId" bigint,   
        "PrincipalValue" numeric, 
        "CodeRevenue" character varying, 
        "Barcode" character varying, 
        "FGTSIdentifier" character varying, 
        "SocialConnectivityCode" bigint, 
        "SocialConnectivityDigit" integer, 
        "PaymentDate" timestamp without time zone, 
        "RateValueType" bigint,
        "Description" character varying, 
        "Identifier" character varying, 
        "Status" integer, 
        "Attempts" integer,
        "ExternalIdentifier" bigint,  
        "CreationDate" timestamp without time zone,
        "UpdateDate" timestamp without time zone,    
        "DeletionDate" timestamp without time zone,  
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
		"ContributorTaxId",
        "OperationId",
        "PrincipalValue",
        "CodeRevenue",
        "Barcode",
        "FGTSIdentifier",
        "SocialConnectivityCode",
        "SocialConnectivityDigit",
        "PaymentDate",
        "RateValueType",
        "Description",
        "Identifier",
		"Status",
        "Attempts",
		"ExternalIdentifier",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."FGTSPayment"
WHERE "Identifier" = "paramIdentifier"
AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getfgtspaymentbyidentifier(character varying)
    OWNER TO "OSB";