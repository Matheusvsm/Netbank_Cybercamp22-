CREATE OR REPLACE FUNCTION public.getlimitedaccountbyid(
	"paramLimitedAccountId" bigint
    )
    RETURNS TABLE(		
        "LimitedAccountId" bigint, 
		"CompanyId" bigint, 
		"Name" character varying, 
		"PhoneNumber" character varying, 
		"TaxId" character varying, 
		"Mail" character varying, 
		"Nickname" character varying, 
		"Bank" character varying, 
		"BankBranch" character varying, 
		"BankAccount" character varying, 
		"BankAccountDigit" character varying, 
		"BirthDate" timestamp without time zone, 
		"TradingName" character varying, 
		"LegalName" character varying, 
		"ConstitutionDate" timestamp without time zone, 
		"Status" integer, 
		"Attempts" integer,
		"Password" character varying,
		"Salt" character varying,
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
SELECT "LimitedAccountId",
        "CompanyId",
        "Name",
        "PhoneNumber",
        "TaxId",
        "Mail",
        "Nickname",
        "Bank",
        "BankBranch",
        "BankAccount",
        "BankAccountDigit",
        "BirthDate",
        "TradingName",
        "LegalName",
        "ConstitutionDate",
        "Status",
        "Attempts",
		"Password",
		"Salt",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"

FROM public."LimitedAccount"

WHERE "paramLimitedAccountId" = "paramLimitedAccountId"
    AND "DeletionDate" IS NULL

$BODY$;
ALTER FUNCTION public.getlimitedaccountbyid(bigint)
    OWNER TO "OSB";