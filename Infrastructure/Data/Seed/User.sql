INSERT INTO "Users" ("CreatedDate","CreatedBy","UpdatedDate","UpdatedBy","FirstName","LastName","Email","Password","Role")
VALUES
((SELECT GETUTCDATE()),'SEED USER',(SELECT GETUTCDATE()),'SEED USER','Miguel','Benedit','admin@test.com','MTIzNDU=',1),
((SELECT GETUTCDATE()),'SEED USER',(SELECT GETUTCDATE()),'SEED USER','User','Seed','user@test.com','MTIzNDU=',2),
((SELECT GETUTCDATE()),'SEED USER',(SELECT GETUTCDATE()),'SEED USER','User2','Seed','user2@test.com','12345',2)

