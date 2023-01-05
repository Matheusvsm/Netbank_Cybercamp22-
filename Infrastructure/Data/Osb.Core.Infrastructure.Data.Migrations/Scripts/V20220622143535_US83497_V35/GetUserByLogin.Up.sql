DROP FUNCTION public.getuserbylogin(text);

CREATE OR REPLACE FUNCTION public.getuserbylogin(
	"paramLogin" text)
    RETURNS TABLE("UserId" bigint, 
	"Login" character varying,
	"Status" integer,
	"IsFirstAccess" boolean,
	"AcceptedTerms" boolean,
	"LoginAttempts" integer,
	"CreationDate" timestamp without time zone, 
	"DeletionDate" timestamp without time zone, 
	"UpdateDate" timestamp without time zone
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
		"AcceptedTerms",
		"LoginAttempts",
		"CreationDate", 
		"DeletionDate", 
		"UpdateDate"
    FROM
		public."User"
	Where
		"Login" = "paramLogin"
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getuserbylogin(text)
    OWNER TO "OSB";