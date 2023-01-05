DROP FUNCTION public.getuserinformationbyuserid(bigint);

CREATE FUNCTION public.getuserinformationbyuserid (
        "paramUserId" bigint
    ) RETURNS TABLE (
        "UserInformationId" bigint, 
        "Name" character varying, 
        "Mail" character varying, 
        "PhoneNumber" character varying, 
        "ZipCode" character varying, 
        "Street" character varying, 
        "Number" character varying, 
        "District" character varying, 
        "Complement" character varying,
        "City" character varying, 
        "State" character varying, 
        "UserId" bigint, 
        "CreationUserId" bigint, 
        "UpdateUserId" bigint, 
        "CreationDate" timestamp without time zone, 
        "UpdateDate" timestamp without time zone, 
        "DeletionDate" timestamp without time zone
    ) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 	"UserInformationId",
		"Name",
		"Mail",
		"PhoneNumber",
		"ZipCode",
		"Street",
		"Number",
		"District",
		"Complement",
		"City",
		"State",
		"UserId",
		"CreationUserId",
		"UpdateUserId",
		"CreationDate",
		"UpdateDate",
		"DeletionDate"
	FROM public."UserInformation"
    WHERE
        ("UserId" = "paramUserId")
        AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getuserinformationbyuserid(bigint)
    OWNER TO "OSB";