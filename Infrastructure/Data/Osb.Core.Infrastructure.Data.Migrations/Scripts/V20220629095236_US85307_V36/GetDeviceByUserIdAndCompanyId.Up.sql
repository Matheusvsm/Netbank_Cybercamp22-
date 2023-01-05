CREATE OR REPLACE FUNCTION public.getdevicebyuseridandcompanyid(
	"paramUserId" bigint,
	"paramCompanyId" bigint
)
RETURNS TABLE(
	"DeviceId" bigint, 
	"Token" character varying, 
	"UserId" bigint,
	"CompanyId" bigint,
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
	"DeviceId",
	"Token",
	"UserId",
	"CompanyId",
	"CreationDate",
	"UpdateDate",
	"DeletionDate",
	"CreationUserId",
	"UpdateUserId"
FROM 
	public."Device"
WHERE
	"UserId" = "paramUserId" AND
	"CompanyId" = "paramCompanyId" AND
	"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getdevicebyuseridandcompanyid(bigint, bigint)
    OWNER TO "OSB";