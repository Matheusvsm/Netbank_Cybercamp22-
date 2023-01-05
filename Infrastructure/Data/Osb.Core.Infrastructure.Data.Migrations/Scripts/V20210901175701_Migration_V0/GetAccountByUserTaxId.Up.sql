CREATE OR REPLACE FUNCTION public.getaccountbyusertaxid(
	"paramTaxId" text
	)
    RETURNS TABLE(
		"AccountId" bigint, 
		"CompanyId" bigint,
		"Name" character varying,
		"Type" bigint,
		"AccountKey" character varying,
		"Status" bigint,
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
		ACC."AccountId",
		ACC."CompanyId",
		ACC."Name",
		ACC."Type",
		ACC."AccountKey",
		ACC."Status",
		ACC."CreationDate",
		ACC."UpdateDate",
		ACC."DeletionDate",
		ACC."CreationUserId",
		ACC."UpdateUserId",
		ACC."TaxId"
	FROM public."Account" AS ACC
		INNER JOIN "Company" AS CO ON CO."CompanyId" = ACC."CompanyId" 
		INNER JOIN "UserAccount" AS UA ON UA."AccountId" = ACC."AccountId" 
		INNER JOIN "User" AS U ON U."UserId" = UA."UserId"
	Where
		U."Login" = "paramTaxId"
	AND 
		U."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getaccountbyusertaxid(text)
    OWNER TO "OSB";
