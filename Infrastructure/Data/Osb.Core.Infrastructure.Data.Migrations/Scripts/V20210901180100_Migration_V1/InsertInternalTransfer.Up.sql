CREATE OR REPLACE FUNCTION public.insertinternaltransfer(
	"paramIdentifier" character varying,
    "paramFromAccountId" bigint,
	"paramToAccountId" bigint,
    "paramOperationId" bigint,
	"paramTransferValue" numeric,
	"paramTransferDate" timestamp without time zone,
	"paramStatus" integer,
	"paramDescription" character varying,    
    "paramUserId" bigint
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."InternalTransfer"
                    (
                    "Identifier",
                    "FromAccountId",
                    "ToAccountId",
                    "TransferValue",
                    "TransferDate",
                    "Status",
					"Description",
                    "OperationId",
                    "CreationDate",
                    "UpdateDate", 
                    "CreationUserId",
                    "UpdateUserId"                     
                     )
	VALUES (
            "paramIdentifier",
            "paramFromAccountId",
            "paramToAccountId",
            "paramTransferValue",
            "paramTransferDate",
            "paramStatus",
			"paramDescription",
            "paramOperationId",
            now(),
            now(), 
            "paramUserId",
            "paramUserId"
           )
$BODY$;

ALTER FUNCTION public.insertinternaltransfer(character varying, bigint, bigint, bigint, numeric, timestamp without time zone, integer, character varying, bigint)
    OWNER TO "OSB";