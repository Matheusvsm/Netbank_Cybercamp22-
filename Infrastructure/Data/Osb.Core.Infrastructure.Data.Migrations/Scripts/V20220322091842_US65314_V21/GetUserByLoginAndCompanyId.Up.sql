CREATE FUNCTION public.GetUserByLoginAndCompanyId(
	"paramLogin" character varying,
	"paramCompanyId" bigint
	)

    RETURNS TABLE(
		"UserId" bigint,
		"AccountId" bigint, 
		"CompanyId" bigint,
		"Login" character varying, 
		"Status" integer, 
		"IsFirstAccess" boolean,
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
		U."UserId",
		UA."AccountId",
		ACC."CompanyId",
		U."Login", 
		U."Status",
		U."IsFirstAccess",
		U."LoginAttempts",
		U."CreationDate", 
		U."DeletionDate", 
		U."UpdateDate"
		FROM
		public."User" AS U
		INNER JOIN "UserAccount" AS UA ON UA."UserId" = U."UserId"
		INNER JOIN "Account" AS ACC ON ACC."AccountId" = UA."AccountId"
	Where
		"Login" = "paramLogin"
	AND
		"CompanyId" = "paramCompanyId"
	AND 
		U."DeletionDate" IS NULL
			
$BODY$;

ALTER FUNCTION public.GetUserByLoginAndCompanyId(character varying, bigint)
    OWNER TO "OSB";