CREATE OR REPLACE FUNCTION public.getactionfunctionbyparameters(
	"paramUserId" bigint,
	"paramAccountId" bigint,
	"paramAction" character varying,
	"paramController" character varying
    )
    RETURNS TABLE(
        "ActionFunctionId" bigint, 
        "Action" character varying, 
        "Controller" character varying, 
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
		AF."ActionFunctionId",
		AF."Action",
		AF."Controller",
		AF."CreationDate",
		AF."UpdateDate",
		AF."DeletionDate",
		AF."CreationUserId",
		AF."UpdateUserId"
		FROM "User" U
			LEFT JOIN "UserAccount" UA ON U."UserId" = UA."UserId" AND UA."AccountId" = "paramAccountId"
			LEFT JOIN "UserAccountProfile" UAP ON UA."UserAccountId" = UAP."UserAccountId"
			LEFT JOIN "Profile" P ON UAP."ProfileId" = P."ProfileId"
			LEFT JOIN "ProfileActionFunction" PAF ON P."ProfileId" = PAF."ProfileId"
			LEFT JOIN "ActionFunction" AF ON PAF."ActionFunctionId" = AF."ActionFunctionId"
	WHERE U."UserId" = "paramUserId"
		AND AF."Action" = "paramAction"
		AND AF."Controller" = "paramController"
		AND U."DeletionDate" IS NULL
		AND UA."DeletionDate" IS NULL
		AND UAP."DeletionDate" IS NULL
		AND P."DeletionDate" IS NULL
		AND PAF."DeletionDate" IS NULL
		AND AF."DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getactionfunctionbyparameters(bigint, bigint, character varying, character varying)
    OWNER TO "OSB";
