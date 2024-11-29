ALTER TABLE [dbo].[UserDetails]
ADD 
    [ProfileImagePath] VARCHAR(255) NULL,  -- Path to the profile image, can be NULL initially
    [Bio] TEXT NULL;  -- User bio, can be NULL if no bio is provided
