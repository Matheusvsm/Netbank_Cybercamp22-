CREATE OR REPLACE FUNCTION public.getpushnotificationbyoperationid(
        "paramOperationId" bigint
    )
    RETURNS TABLE(
        "PushNotificationId" bigint,
        "OperationId" bigint,
        "UserId" bigint,
        "CompanyId" bigint,
        "Title" character varying,
        "Body" character varying,
        "Status" integer,
        "SendDate" timestamp without time zone,
        "Attempts" integer,
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
    "PushNotificationId",
    "OperationId",
    "UserId",
    "CompanyId",
    "Title",
    "Body",
    "Status",
    "SendDate",
    "Attempts",
    "CreationDate",
    "UpdateDate",
    "DeletionDate",
    "CreationUserId",
    "UpdateUserId"
FROM
    public."PushNotification" 
WHERE
    "DeletionDate" IS NULL AND
    "OperationId" = "paramOperationId"
$BODY$;