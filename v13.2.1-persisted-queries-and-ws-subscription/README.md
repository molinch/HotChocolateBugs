# Steps to reproduce
- Make sure neither backend or frontend are running
- Run the backend, it will open a browser on port 7001 with the Banana Cake Pop UI
- Run the frontend with `npm start` it will open a browser on port 7000 which will show an error in the developer tools console. It is expected since subscriptionMode query parameter isn't set.
- Go to http://localhost:7000/?subscriptionMode=ws and open the developer tools console you will see the HotChocolate error `There are no operations in the GraphQL document.`
- Now go to http://localhost:7000/?subscriptionMode=see and open the developer tools console you will see messages coming every 500ms, these are from the GraphQL subscription
- Now go to http://localhost:7000/?subscriptionMode=ws and open the developer tools console you will see messages coming every 500ms, these are from the GraphQL subscription. Now using WebSockets finally works.

# Other steps that do work
- If you directly connect to the GraphQL subscription using SSE
- If you directly connect to the GraphQL subscription without persisted queries, using SSE or WS

# Conclusion
The bug is related to the combination of:
- persisted queries
- WebSockets usage
- having the first subscription call using WebSockets (some cache is probably not yet filled)