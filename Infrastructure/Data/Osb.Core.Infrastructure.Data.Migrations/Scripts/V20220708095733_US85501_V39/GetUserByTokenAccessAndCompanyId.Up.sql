CREATE FUNCTION public.getuserbytokenaccessandcompanyid(
	"paramTokenAccess" character varying,
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
        "UpdateDate" timestamp without time zone,
		"AcceptedTerms" boolean
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
		U."UpdateDate",
		U."AcceptedTerms"
		FROM
        public."RememberLoginToken" AS RMT
		INNER JOIN "User" AS U ON RMT."UserId" = U."UserId"
        INNER JOIN "UserAccount" AS UA ON UA."UserId" = U."UserId"
		INNER JOIN "Account" AS ACC ON ACC."AccountId" = UA."AccountId"
	Where
		RMT."TokenAccess" = "paramTokenAccess"
	AND
		ACC."CompanyId" = "paramCompanyId"
	AND 
		U."DeletionDate" IS NULL
			
$BODY$;

ALTER FUNCTION public.getuserbytokenaccessandcompanyid(character varying, bigint)
    OWNER TO "OSB";