CREATE FUNCTION public.getuseraccountbyaccountkeyanduserid(
	"paramAccountKey" character varying,
	"paramUserId" bigint
	)
    RETURNS TABLE
	(
		"UserAccountId" bigint,
		"AccountId" bigint,
		"UserId" bigint,
		"CreationDate" timestamp without time zone, 
		"UpdateDate" timestamp without time zone, 
		"DeletionDate" timestamp without time zone, 
		"CreationUserId" bigint, 
		"UpdateUserId" bigint
	)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
	UA."UserAccountId",
	UA."AccountId",
	UA."UserId",
	UA."CreationDate",
	UA."UpdateDate",
	UA."DeletionDate",
	UA."CreationUserId",
	UA."UpdateUserId"
FROM 
	"UserAccount" UA
	INNER JOIN "Account" A ON UA."AccountId" = A."AccountId"
WHERE
	A."AccountKey" = "paramAccountKey"
	AND UA."UserId" = "paramUserId"
	AND UA."DeletionDate" IS NULL
	AND A."DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getuseraccountbyaccountkeyanduserid(character varying, bigint)
    OWNER TO "OSB";