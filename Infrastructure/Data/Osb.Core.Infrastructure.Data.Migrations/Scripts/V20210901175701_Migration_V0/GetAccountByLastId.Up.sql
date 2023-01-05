CREATE OR REPLACE FUNCTION public.getaccountbylastid(
	)
    RETURNS TABLE(
			"AccountId" bigint, 
			"CompanyId" bigint, 
			"Name" character varying,
			"Type" bigint,
			"Status" bigint, 
			"SubAccountId" bigint,
			"CreationDate" timestamp without time zone,
			"UpdateDate" timestamp without time zone,
			"DeletionDate" timestamp without time zone,
			"CreationUserId" bigint, 
			"UpdateUserId" bigint,
			"TaxId" character varying
			)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT
	"AccountId",
	"CompanyId",
	"Name", 
	"Type", 
	"Status",
	"SubAccountId",
	"CreationDate",
	"UpdateDate", 
	"DeletionDate",
	"CreationUserId", 
	"UpdateUserId", 
	"TaxId"
	FROM public."Account"
	Where
		"AccountId" = (SELECT MAX("AccountId") FROM public."Account")
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getaccountbylastid()
    OWNER TO "OSB";
