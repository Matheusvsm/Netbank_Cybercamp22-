DROP FUNCTION public.gettopupbyexternalidentifierandproductkey(character varying, bigint);

CREATE OR REPLACE FUNCTION public.gettopupbyexternalidentifierandproductkey(
	"paramProductKey" character varying,
	"paramExternalIdentifier" bigint)
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
	"ProductKey" = "paramProductKey"
AND "ExternalIdentifier" = "paramExternalIdentifier"
AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.gettopupbyexternalidentifierandproductkey(character varying, bigint)
    OWNER TO "OSB";