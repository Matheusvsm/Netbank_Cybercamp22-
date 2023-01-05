CREATE OR REPLACE FUNCTION public.getcardownerbyid(
	"paramCardOwnerId" bigint)
    RETURNS TABLE("CardOwnerId" bigint, "OwnerTaxId" character varying, "FullName" character varying, "Phone" character varying, "Mail" character varying, "Bank" character varying, "BankBranch" character varying, "BankAccount" character varying, "BankAccountDigit" character varying, "CreationDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT (
		"CardOwnerId",
		"OwnerTaxId",
		"FullName",
		"Phone",
		"Mail",
		"Bank",
		"BankBranch",
		"BankAccount",
		"BankAccountDigit",
		"CreationDate",
		"DeletionDate",
		"UpdateDate",
		"CreationUserId",
		"UpdateUserId"
		)
	FROM public."CardOwner"
	WHERE "CardOwnerId" = "paramCardOwnerId" AND "DeletionDate" is NULL
$BODY$;

ALTER FUNCTION public.getcardownerbyid(bigint)
    OWNER TO "OSB";