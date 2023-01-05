CREATE FUNCTION public.getuseraccountprofile(
	"paramUserAccountId" bigint,
	"paramName" text)
    RETURNS TABLE("ProfileId" bigint, "Name" text, "UserId" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT
		PR."ProfileId",
		PR."Name",
		UA."UserId",
		PR."CreationDate",
		PR."UpdateDate",
		PR."DeletionDate",
		PR."CreationUserId",
		PR."UpdateUserId"
FROM 
		"UserAccountProfile" UAP
INNER JOIN
		"Profile" PR
ON
		UAP."ProfileId" = PR."ProfileId"
		AND UAP."DeletionDate" IS NULL
		AND PR."DeletionDate" IS NULL
INNER JOIN 
		"UserAccount" UA
ON
		UAP."UserAccountId" = UA."UserAccountId"
WHERE
		PR."Name" = "paramName" AND
		UAP."UserAccountId" = "paramUserAccountId"
$BODY$;
ALTER FUNCTION public.getuseraccountprofile(bigint, text)
    OWNER TO "OSB";
