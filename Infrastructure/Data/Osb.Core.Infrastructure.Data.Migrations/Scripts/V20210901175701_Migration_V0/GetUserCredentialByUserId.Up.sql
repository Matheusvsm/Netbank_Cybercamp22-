
CREATE OR REPLACE FUNCTION public.getusercredentialbyuserid(
	"paramUserId" bigint)
    RETURNS TABLE(
        "UserCredentialId" bigint, 
        "Password" character varying, 
        "Salt" character varying,
        "CreationDate" timestamp without time zone, 
        "UpdateDate" timestamp without time zone, 
        "DeletionDate" timestamp without time zone, 
        "UserId" bigint, 
        "CreationUserId" bigint, 
        "UpdateUserId" bigint
    ) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
    "UserCredentialId",
    "Password",
	"Salt",
	"CreationDate",
    "UpdateDate",
    "DeletionDate",
	"UserId",
    "CreationUserId",
    "UpdateUserId"
	
    FROM
        public."UserCredential"
    Where
        "UserId" = "paramUserId"
	AND
		"DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getusercredentialbyuserid(bigint)
    OWNER TO "OSB";
