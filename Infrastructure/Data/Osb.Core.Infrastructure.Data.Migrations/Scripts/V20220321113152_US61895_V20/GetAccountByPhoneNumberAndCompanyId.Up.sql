CREATE FUNCTION public.getaccountbyphonenumberandcompanyid(
	"paramPhoneNumber" character varying,
	"paramCompanyId" bigint)
    RETURNS TABLE("AccountId" bigint, "CompanyId" bigint, "TaxId" character varying, "Name" character varying, "Type" bigint, "Status" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint, "AccountKey" character varying, "PhoneNumber" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
			   ACC."AccountId",
			   ACC."CompanyId",
			   ACC."TaxId",
			   ACC."Name",
			   ACC."Type",
			   ACC."Status",
			   ACC."CreationDate",
			   ACC."UpdateDate",
			   ACC."DeletionDate",
			   ACC."CreationUserId",
			   ACC."UpdateUserId",
			   ACC."AccountKey",
			   UI."PhoneNumber"
		FROM 
			public."Account" AS ACC
		INNER JOIN public."User" AS U ON ACC."TaxId" = U."Login"
		INNER JOIN public."UserInformation" AS UI ON U."UserId" = UI."UserId"
		INNER JOIN public."UserAccount" AS UA ON U."UserId" = UA."UserId"
		WHERE
			(UI."PhoneNumber" = "paramPhoneNumber")
			AND (ACC."CompanyId" = "paramCompanyId")
			AND (ACC."AccountId" = UA."AccountId")
			AND (U."UserId" = UA."UserId")
			AND ACC."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getaccountbyphonenumberandcompanyid(character varying, bigint)
    OWNER TO "OSB";