CREATE FUNCTION public.getuseraccountbyuseridandaccountid(
	"paramUserId" bigint,
	"paramAccountId" bigint)
    RETURNS TABLE("UserAccountId" bigint, "AccountId" bigint, "UserId" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT 
	"UserAccountId",
	"AccountId",
	"UserId",
	"CreationDate",
	"UpdateDate",
	"DeletionDate",
	"CreationUserId",
	"UpdateUserId"
FROM 
	"UserAccount"
WHERE
	"UserId" = "paramUserId" AND
	"AccountId" = "paramAccountId" AND
	"DeletionDate" IS NULL
$BODY$;
ALTER FUNCTION public.getuseraccountbyuseridandaccountid(bigint, bigint)
    OWNER TO "OSB";