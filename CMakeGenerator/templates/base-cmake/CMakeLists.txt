cmake_minimum_required(VERSION <CMAKE_VERSION_NUM>)
set(CMAKE_CXX_STANDARD <CXX_VERSION_NUM>)

# Version number is major, minor, fix
project(<PROJECT_NAME> VERSION 0.1.0)

set(HEADER_DIR "${CMAKE_SOURCE_DIR}/include")
set(LIB_DIR "${CMAKE_SOURCE_DIR}/lib")

file(GLOB_RECURSE SourceList 
	${CMAKE_SOURCE_DIR}/src/*.cpp
	${CMAKE_SOURCE_DIR}/src/*.cxx
	${CMAKE_SOURCE_DIR}/src/*.c
)
file(GLOB_RECURSE HeaderList 
	${HEADER_DIR}/*.h
	${HEADER_DIR}/*.hpp
)
file(GLOB_RECURSE LibraryList
	${LIB_DIR}/*.a
	${LIB_DIR}/*.dll
)

include_directories(
	${HEADER_DIR}
)

add_executable(${CMAKE_PROJECT_NAME} main.cpp ${SourceList} ${HeaderList})

target_link_libraries(${CMAKE_PROJECT_NAME} ${LibraryList})