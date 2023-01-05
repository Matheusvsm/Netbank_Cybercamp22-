CREATE OR REPLACE FUNCTION public.getauthorizationtokenbyphonenumber(
	"paramPhoneNumber" character varying
    )
    RETURNS TABLE(
		"AuthorizationTokenId" bigint, 
		"UserId" bigint,
		"AccountId" bigint, 
		"Code" character varying,
		"ExpirationDate" timestamp without time zone,
		"Salt" character varying,
		"Status" integer,
		"CreationDate" timestamp without time zone, 
		"UpdateDate" timestamp without time zone,
		"CreationUserId" bigint, 
		"UpdateUserId" bigint, 
		"DeletionDate" timestamp without time zone,
		"ValidateAttempts" integer
        ) 
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
        "PhoneNumber" = "paramPhoneNumber" AND
		"DeletionDate" IS NULL
          order by "AuthorizationTokenId" desc;
$BODY$;

ALTER FUNCTION public.getauthorizationtokenbyphonenumber(character varying)
    OWNER TO "OSB";