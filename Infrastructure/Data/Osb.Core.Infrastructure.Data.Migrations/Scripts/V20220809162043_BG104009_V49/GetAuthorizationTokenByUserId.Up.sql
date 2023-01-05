DROP FUNCTION public.getauthorizationtokenbyuseridandaccountid(bigint, bigint);

CREATE OR REPLACE FUNCTION public.getauthorizationtokenbyuserid(
	"paramUserId" bigint)
    RETURNS TABLE("AuthorizationTokenId" bigint, "UserId" bigint, "Code" character varying, "ExpirationDate" timestamp without time zone, "Salt" character varying, "Status" smallint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint, "DeletionDate" timestamp without time zone, "ValidateAttempts" smallint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
        "AuthorizationTokenId",
        "UserId",
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
		"DeletionDate" IS NULL
          order by "AuthorizationTokenId" desc;
$BODY$;

ALTER FUNCTION public.getauthorizationtokenbyuserid(bigint)
    OWNER TO "OSB";
