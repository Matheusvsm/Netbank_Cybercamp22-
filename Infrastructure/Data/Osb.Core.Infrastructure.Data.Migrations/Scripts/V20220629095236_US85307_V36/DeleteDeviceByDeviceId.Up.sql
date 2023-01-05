CREATE OR REPLACE FUNCTION public.deletedevicebydeviceid(
    "paramDeviceId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
    Update public."Device"
        set "DeletionDate" = now(),
            "UpdateDate" = now()    
    WHERE
        "DeletionDate" IS NULL AND
        "DeviceId" = "paramDeviceId"
    $BODY$;
ALTER FUNCTION public.deletedevicebydeviceid(bigint)
OWNER TO "OSB";