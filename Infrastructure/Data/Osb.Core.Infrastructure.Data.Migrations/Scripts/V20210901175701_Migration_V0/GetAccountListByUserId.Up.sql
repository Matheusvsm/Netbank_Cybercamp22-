CREATE OR REPLACE FUNCTION public.getaccountlistbyuserid(
	"paramUserId" bigint)
    RETURNS TABLE("AccountId" bigint, "CompanyId" bigint, "Name" character varying, "Type" bigint, "Status" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint, "TaxId" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT ACC."AccountId",
	   ACC."CompanyId",
	   ACC."Name",
	   ACC."Type",
	   ACC."Status",
	   ACC."CreationDate",
	   ACC."UpdateDate",
	   ACC."DeletionDate",
	   ACC."CreationUserId",
	   ACC."UpdateUserId",
	   ACC."TaxId"
	  FROM public."Account" AS ACC
		INNER JOIN "UserAccount" AS UA ON UA."AccountId" = Acc."AccountId" 
		INNER JOIN "User" AS U ON U."UserId" = UA."UserId"
	  Where
		U."UserId" = "paramUserId"
	  AND 
		U."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getaccountlistbyuserid(bigint)
    OWNER TO "OSB";
