SET IDENTITY_INSERT EventTypeModel ON;

INSERT INTO EventTypeModel (EventTypeId,EventType )   
VALUES ('1','Corporate'),
       ('2','Wedding'),
       ('3','Party'),
       ('4','Funeral'),
      ('5','Other');

SET IDENTITY_INSERT EventTypeModel OFF;