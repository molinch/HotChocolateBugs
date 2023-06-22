import { createClient } from 'graphql-ws'

export default function wsSubscribe() {
    const client = createClient({
        url: 'wss://localhost:7001/api/graphql'
    })

    const unsubscribe = client.subscribe(
        {
            id: 'persisted-subscription',
            query: ''
        },
        {
            next: response => console.log('Message from WS subscription', response),
            error: error => console.error('Error from WS subscription', error),
            complete: () => {}
        }
    )

    return { client, unsubscribe }
}