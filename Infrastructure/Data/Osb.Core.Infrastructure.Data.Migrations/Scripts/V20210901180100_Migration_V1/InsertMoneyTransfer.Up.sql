CREATE OR REPLACE FUNCTION public.insertmoneytransfer(
	"paramAccountId" bigint,
	"paramIdentifier" character varying,
	"paramOperationId" bigint,
	"paramToTaxId" character varying,
	"paramToName" character varying,
	"paramBankingDataId" bigint,
	"paramTransferValue" numeric,
	"paramTransferDate" timestamp without time zone,
	"paramStatus" integer,
	"paramDescription" character varying,	
	"paramUserId" bigint
	)
    RETURNS TABLE("MoneyTransferId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."MoneyTransfer"(
					"FromAccountId",										
					"Identifier",
					"OperationId",		
					"ToTaxId",
					"ToName",
					"BankingDataId",
					"TransferValue",
					"TransferDate",
					"Status",
					"Description",	
					"CreationDate",
					"UpdateDate",					
					"CreationUserId",
					"UpdateUserId"
					)

			VALUES (
					"paramAccountId",
					"paramIdentifier",
					"paramOperationId",
					"paramToTaxId",
					"paramToName",
					"paramBankingDataId",
					"paramTransferValue",
					"paramTransferDate",
					"paramStatus",
					"paramDescription",
					now(),
					now(),
					"paramUserId",
					"paramUserId"
					) RETURNING "MoneyTransferId";
$BODY$;

ALTER FUNCTION public.insertmoneytransfer(bigint, character varying, bigint, character varying, character varying, bigint, numeric, timestamp without time zone, integer, character varying, bigint)
	OWNER TO "OSB";