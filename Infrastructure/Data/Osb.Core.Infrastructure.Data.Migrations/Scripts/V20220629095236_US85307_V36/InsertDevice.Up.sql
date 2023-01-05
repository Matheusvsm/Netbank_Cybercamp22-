CREATE OR REPLACE FUNCTION public.insertdevice(
	"paramToken" character varying,
	"paramUserId" bigint,
	"paramCompanyId" bigint)
    RETURNS TABLE("DeviceId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."Device"
                    (
					"Token",
					"UserId",
					"CompanyId",
					"CreationDate",
					"UpdateDate",
					"DeletionDate",
					"CreationUserId",
					"UpdateUserId"
					 )
				VALUES 
					(
					"paramToken",
					"paramUserId",
					"paramCompanyId",
					now(),
					now(),
					null,
					"paramUserId",
					"paramUserId"
					) RETURNING "DeviceId"
$BODY$;

ALTER FUNCTION public.insertdevice(character varying, bigint, bigint)
    OWNER TO "OSB";
