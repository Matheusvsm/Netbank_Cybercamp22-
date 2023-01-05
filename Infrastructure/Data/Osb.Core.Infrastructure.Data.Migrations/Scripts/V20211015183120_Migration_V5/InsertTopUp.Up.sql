CREATE OR REPLACE FUNCTION public.inserttopup(
	"paramAccountId" bigint,
    "paramOperationId" bigint,
	"paramProductType" integer,
	"paramBatchIdentifier" character varying,
	"paramProductKey" character varying,
	"paramProductValue" numeric,
	"paramContractIdentifier" character varying,
	"paramOriginNSU" character varying,
	"paramStatus" integer,
	"paramUserId" bigint)
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
            NOW(),
            NOW(),            
            "paramUserId",
            "paramUserId"
           ) RETURNING "TopUpId";
$BODY$;

ALTER FUNCTION public.inserttopup(bigint, bigint, integer, character varying, character varying, numeric, character varying, character varying, integer, bigint)
    OWNER TO "OSB";
