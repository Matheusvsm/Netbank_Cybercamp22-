CREATE OR REPLACE FUNCTION public.gettopuplistbystatus(
	"paramStatus" integer
	)
    RETURNS TABLE(
		"TopUpId" bigint, 
		"AccountId" bigint, 
		"OperationId" bigint,
		"ProductType" integer, 
		"BatchIdentifier" character varying, 
		"ProductKey" character varying, 
		"ProductValue" numeric, 
		"ContractIdentifier" character varying, 
		"OriginNSU" character varying, 
		"ExternalIdentifier" character varying, 
		"UrlReceipt" character varying, 
		"Status" integer, 
		"Attempts" integer) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  "TopUpId",
		"AccountId",
		"OperationId",
		"ProductType",
		"BatchIdentifier",
		"ProductKey",
		"ProductValue",
		"ContractIdentifier",
		"OriginNSU",
		"ExternalIdentifier",
		"UrlReceipt",
		"Status",
		"Attempts"
	FROM 
		public."TopUp"
	WHERE 
		"Status" = "paramStatus" AND
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.gettopuplistbystatus(integer)
    OWNER TO "OSB";