import React from 'react';

class Posts extends React.Component {
  // Constructor: initialize state and bind methods
  constructor(props) {
    super(props);
    

    // If you have event handlers, bind them here, example:
    // this.handleClick = this.handleClick.bind(this);
  }

  // Lifecycle: invoked immediately after component is mounted
  componentDidMount() {
    this.fetchPosts();
  }

  // Custom method to fetch posts data (example API call)
  fetchPosts() {
    fetch('https://jsonplaceholder.typicode.com/posts') // example placeholder API
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => this.setState({ posts: data, loading: false }))
      .catch(error => this.setState({ error, loading: false }));
  }

  // Lifecycle: control re-rendering (optional optimization)
  shouldComponentUpdate(nextProps, nextState) {
    // Rerender only if posts or error or loading changed
    return (
      nextState.posts !== this.state.posts ||
      nextState.error !== this.state.error ||
      nextState.loading !== this.state.loading
    );
  }

  // Lifecycle: catch errors during rendering, lifecycle methods and constructors in child components
  componentDidCatch(error, errorInfo) {
    console.error("Error caught in Posts component:", error, errorInfo);
    // update state to display fallback UI if you want
    this.setState({ error: error.toString(), loading: false });
  }

  render() {
    const { posts, loading, error } = this.state;

    if (loading) return <p>Loading posts...</p>;

    if (error) return <p style={{ color: 'red' }}>Error: {error}</p>;

    return (
      <div>
        <h2>Posts List</h2>
        <ul>
          {posts.map(post => (
            <li key={post.id}><strong>{post.title}</strong><p>{post.body}</p></li>
          ))}
        </ul>
      </div>
    );
  }
}

export default Posts;
