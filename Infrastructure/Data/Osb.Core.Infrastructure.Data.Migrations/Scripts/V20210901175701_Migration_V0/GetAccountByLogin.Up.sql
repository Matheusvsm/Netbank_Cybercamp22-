CREATE OR REPLACE FUNCTION public.getaccountbylogin(
	"paramLogin" text)
    RETURNS TABLE("AccountId" bigint, "CompanyId" bigint, "TaxId" character varying, "Name" character varying, "Status" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT ACC."AccountId",
	   ACC."CompanyId",
	   ACC."TaxId",
	   ACC."Name",
	   ACC."Status",
	   ACC."CreationDate",
	   ACC."UpdateDate",
	   ACC."DeletionDate",
	   ACC."CreationUserId",
	   ACC."UpdateUserId"   
	FROM public."Account" AS ACC
		INNER JOIN "UserAccount" AS UA ON UA."AccountId" = Acc."AccountId" 
		INNER JOIN "User" AS U ON U."UserId" = UA."UserId"
	Where
		U."Login" = "paramLogin"
	AND 
		U."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getaccountbylogin(text)
    OWNER TO "OSB";
