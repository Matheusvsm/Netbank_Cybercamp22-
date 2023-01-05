DROP FUNCTION public.getuserbyid(bigint);

CREATE FUNCTION public.getuserbyid(
	"paramUserId" bigint
	)
    RETURNS TABLE(
		"UserId" bigint, 
		"Login" character varying, 
		"Status" integer, 
		"IsFirstAccess" boolean,
		"LoginAttempts" integer, 
		"CreationDate" timestamp without time zone, 
		"UpdateDate" timestamp without time zone,
		"DeletionDate" timestamp without time zone,
		"AcceptedTerms" boolean
		) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
        "UserId",
		"Login", 
		"Status",
		"IsFirstAccess",
		"LoginAttempts",
		"CreationDate", 
		"UpdateDate",
		"DeletionDate",
		"AcceptedTerms"
    FROM
		public."User"
	Where
		"UserId" = "paramUserId"
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getuserbyid(bigint)
    OWNER TO "OSB";
