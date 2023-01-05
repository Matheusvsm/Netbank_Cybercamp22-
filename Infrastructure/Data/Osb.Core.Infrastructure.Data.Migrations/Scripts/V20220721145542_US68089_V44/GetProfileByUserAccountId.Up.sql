CREATE FUNCTION public.getprofilebyuseraccountid(
	"paramUserAccountId" bigint)
    RETURNS TABLE("ProfileId" bigint, "Name" text, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT
		PR."ProfileId",
		PR."Name",		
		PR."CreationDate",
		PR."UpdateDate",
		PR."DeletionDate",
		PR."CreationUserId",
		PR."UpdateUserId"
FROM 
		"Profile" PR
INNER JOIN
		"UserAccountProfile" UA
ON
		PR."ProfileId" = UA."ProfileId"		
WHERE
		UA."UserAccountId" = "paramUserAccountId" AND
        UA."DeletionDate" IS NULL AND
        PR."DeletionDate" IS NULL
$BODY$;
ALTER FUNCTION public.getprofilebyuseraccountid(bigint)
    OWNER TO "OSB";