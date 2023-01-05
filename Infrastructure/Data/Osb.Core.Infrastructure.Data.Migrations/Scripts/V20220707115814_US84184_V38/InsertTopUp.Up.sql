DROP FUNCTION public.inserttopup(bigint, bigint, integer, character varying, character varying, numeric, character varying, character varying, integer, bigint);

CREATE FUNCTION public.inserttopup(
	"paramAccountId" bigint,
	"paramOperationId" bigint,
	"paramProductType" integer,
	"paramBatchIdentifier" character varying,
	"paramProductKey" character varying,
	"paramProductValue" numeric,
	"paramContractIdentifier" character varying,
	"paramOriginNSU" character varying,
	"paramStatus" integer,
	"paramUserId" bigint,
    "paramPeriodicRepetition" integer,
    "paramTopUpDate" timestamp without time zone,
    "paramIsRecurrent" boolean)
    RETURNS TABLE("TopUpId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."TopUp"
                    (
                    "AccountId",
                    "OperationId",
                    "ProductType",
                    "BatchIdentifier",
                    "ProductKey",
                    "ProductValue",
                    "ContractIdentifier",
                    "OriginNSU",
                    "Status",
                    "PeriodicRepetition",
                    "TopUpDate",
                    "IsRecurrent",
                    "CreationDate",
                    "UpdateDate",
                    "CreationUserId",
                    "UpdateUserId"
                    )
	VALUES (
            "paramAccountId",
            "paramOperationId",
            "paramProductType",
            "paramBatchIdentifier",
            "paramProductKey",
            "paramProductValue",
            "paramContractIdentifier",
            "paramOriginNSU",
            "paramStatus",
            "paramPeriodicRepetition",
            "paramTopUpDate",
            "paramIsRecurrent",
            NOW(),
            NOW(),            
            "paramUserId",
            "paramUserId"
           ) 
           RETURNING "TopUpId";
$BODY$;

ALTER FUNCTION public.inserttopup(bigint, bigint, integer, character varying, character varying, numeric, character varying, character varying, integer, bigint, integer, timestamp without time zone, boolean)
    OWNER TO "OSB";
