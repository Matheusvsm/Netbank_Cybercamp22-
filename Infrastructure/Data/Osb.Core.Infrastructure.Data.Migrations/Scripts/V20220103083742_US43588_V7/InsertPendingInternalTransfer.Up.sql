CREATE OR REPLACE FUNCTION public.insertpendinginternaltransfer(
	"paramAccountId" bigint,
	"paramPhoneNumber" character varying,
	"paramCountryCode" character varying,
	"paramValue" numeric,
	"Identifier" character varying,
	"paramFromTaxId" character varying,
	"paramFromBank" character varying,
	"paramFromBankBranch" character varying,
	"paramFromBankAccount" character varying,
	"paramFromBankAccountDigit" character varying,
	"paramUserId" bigint,
	"paramStatus" integer,
	"paramOperationId" bigint)
    RETURNS TABLE("PendingInternalTransferId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."PendingInternalTransfer"(
		"AccountId",
		"PhoneNumber", 
		"CountryCode", 
		"Value", 
		"Identifier", 
		"FromTaxId", 
		"FromBank", 
		"FromBankBranch", 
		"FromBankAccount", 
		"FromBankAccountDigit",
		"Status",
		"OperationId",
		"CreationDate", 		 
		"UpdateDate", 
		"CreationUserId", 
		"UpdateUserId"
	)
	VALUES (
		"paramAccountId",
		"paramPhoneNumber",
		"paramCountryCode",
		"paramValue",
		"Identifier",
		"paramFromTaxId",
		"paramFromBank",
		"paramFromBankBranch",
		"paramFromBankAccount",
		"paramFromBankAccountDigit",
		"paramStatus",
		"paramOperationId",
		now(),		
		now(),
		"paramUserId",
		"paramUserId"
	)
	RETURNING "PendingInternalTransferId";
$BODY$;

ALTER FUNCTION public.insertpendinginternaltransfer(bigint, character varying, character varying, numeric, character varying, character varying, character varying, character varying, character varying, character varying, bigint, integer, bigint)
    OWNER TO "OSB";
