import { createClient } from 'graphql-sse'

export default function sseSubscribe() {
    const client = createClient({
        url: 'https://localhost:7001/api/graphql'
    })

    const unsubscribe = client.subscribe(
        {
            id: 'persisted-subscription',
            query: ''
        },
        {
            next: response => console.log('Message from SSE subscription', response),
            error: error => console.error('Error from SSE subscription', error),
            complete: () => {}
        }
    )

    return { client, unsubscribe }
}