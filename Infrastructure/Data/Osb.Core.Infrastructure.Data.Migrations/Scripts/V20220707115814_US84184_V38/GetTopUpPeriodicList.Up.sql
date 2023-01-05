CREATE FUNCTION public.getTopUpPeriodicList(
	"paramAccountId" bigint,
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
		"Attempts" integer,
		"PeriodicRepetition" integer,
		"TopUpDate" timestamp without time zone,
		"IsRecurrent" boolean)
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
		"Attempts",
		"PeriodicRepetition",
		"TopUpDate",
		"IsRecurrent"
	FROM 
		public."TopUp"
	WHERE 
		"AccountId" = "paramAccountId" AND
		"Status" = "paramStatus" AND
		"IsRecurrent" = true AND
		"DeletionDate" IS NULL;
$BODY$;
ALTER FUNCTION public.getTopUpPeriodicList(bigint, integer)
    OWNER TO "OSB";