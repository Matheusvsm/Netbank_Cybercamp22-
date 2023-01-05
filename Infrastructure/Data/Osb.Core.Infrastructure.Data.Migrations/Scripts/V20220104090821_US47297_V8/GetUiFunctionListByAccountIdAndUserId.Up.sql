CREATE OR REPLACE FUNCTION public.getuifunctionlistbyaccountidanduserid(
	"paramAccountId" bigint,
	"paramUserId" bigint)
    RETURNS TABLE("Code" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
		UIF."Code"
		
	FROM 
		public."UIFunction" AS UIF 
		INNER JOIN "UserAccount" AS UA ON UA."UserId" = UA."UserId"
		INNER JOIN "UserAccountProfile" AS UAP ON UAP."UserAccountId" = UA."UserAccountId"
		INNER JOIN "ProfileUIFunction" AS PR ON PR."ProfileId" = UAP."ProfileId"

	WHERE
		UA."AccountId" = "paramAccountId"
		AND UA."UserId" = "paramUserId" 
		AND UIF."UIFunctionId" = PR."UIFunctionId"
		AND UA."DeletionDate" IS NULL ORDER BY UIF."UIFunctionId";
$BODY$;

ALTER FUNCTION public.getuifunctionlistbyaccountidanduserid(bigint, bigint)
    OWNER TO "OSB";