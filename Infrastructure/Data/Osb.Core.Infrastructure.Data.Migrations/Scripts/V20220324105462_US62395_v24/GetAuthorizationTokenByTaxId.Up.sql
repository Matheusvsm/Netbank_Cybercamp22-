DROP FUNCTION public.getauthorizationtokenbyphonenumber(character varying);

CREATE OR REPLACE FUNCTION public.getauthorizationtokenbytaxid(
	"paramTaxId" character varying
    )
    RETURNS TABLE(
		"AuthorizationTokenId" bigint, 
		"UserId" bigint,
		"AccountId" bigint, 
        "TaxId" character varying,
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
        "TaxId",
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
        "TaxId" = "paramTaxId" AND
		"DeletionDate" IS NULL
          order by "AuthorizationTokenId" desc;
$BODY$;

ALTER FUNCTION public.getauthorizationtokenbytaxid(character varying)
    OWNER TO "OSB";