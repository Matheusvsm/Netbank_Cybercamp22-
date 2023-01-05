CREATE OR REPLACE FUNCTION public.getauthorizationtokenbyuseridandaccountid(
	"paramUserId" bigint, "paramAccountId" bigint)
    RETURNS TABLE(
		"AuthorizationTokenId" bigint, 
		"UserId" bigint,
		"AccountId" bigint, 
		"Code" character varying,
		"ExpirationDate" timestamp without time zone,
		"Salt" character varying,
		"Status" smallint,
		"CreationDate" timestamp without time zone, 
		"UpdateDate" timestamp without time zone,
		"CreationUserId" bigint, 
		"UpdateUserId" bigint, 
		"DeletionDate" timestamp without time zone,
		"ValidateAttempts" smallint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
        "AuthorizationTokenId",
        "UserId",
		"AccountId",
		"Code",
        "ExpirationDate",
        "Salt",
        "Status",
		"CreationDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId",
        "DeletionDate",
        "ValidateAttempts"
		
    FROM
		public."AuthorizationToken"
	Where
        "Status" = 0 AND
        "UserId" = "paramUserId" AND
        "AccountId" = "paramAccountId" AND 
		"DeletionDate" IS NULL
          order by "AuthorizationTokenId" desc;
$BODY$;

ALTER FUNCTION public.getauthorizationtokenbyuseridandaccountid(bigint,bigint)
    OWNER TO "OSB";