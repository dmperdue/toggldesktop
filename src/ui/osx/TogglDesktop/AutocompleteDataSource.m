//
//  AutocompleteDataSource.m
//  Toggl Desktop on the Mac
//
//  Created by Tanel Lebedev on 19/11/2013.
//  Copyright (c) 2013 TogglDesktop developers. All rights reserved.
//

#import "AutocompleteDataSource.h"
#import "toggl_api.h"
#import "UIEvents.h"
#import "AutocompleteItem.h"

@implementation AutocompleteDataSource

extern void *ctx;

- (id)initWithNotificationName:(NSString *)notificationName
{
	self = [super init];

	self.orderedKeys = [[NSMutableArray alloc] init];
	self.filteredOrderedKeys = [[NSMutableArray alloc] init];
	self.dictionary = [[NSMutableDictionary alloc] init];

	[[NSNotificationCenter defaultCenter] addObserver:self
											 selector:@selector(startDisplayAutocomplete:)
												 name:notificationName
											   object:nil];
	return self;
}

- (NSString *)completedString:(NSString *)partialString
{
	@synchronized(self)
	{
		for (NSString *text in self.filteredOrderedKeys)
		{
			if ([[text commonPrefixWithString:partialString
									  options:NSCaseInsensitiveSearch] length] == [partialString length])
			{
				return text;
			}
		}
	}
	return @"";
}

- (NSString *)get:(NSString *)key
{
	NSString *object = nil;

	@synchronized(self)
	{
		object = [self.dictionary objectForKey:key];
	}
	return object;
}

- (void)startDisplayAutocomplete:(NSNotification *)notification
{
	[self performSelectorOnMainThread:@selector(displayAutocomplete:)
						   withObject:notification.object
						waitUntilDone:NO];
}

- (void)displayAutocomplete:(NSMutableArray *)entries
{
	NSAssert([NSThread isMainThread], @"Rendering stuff should happen on main thread");

	@synchronized(self)
	{
		[self.orderedKeys removeAllObjects];
		[self.dictionary removeAllObjects];
		for (AutocompleteItem *item in entries)
		{
			NSString *key = item.Text;
			if ([self.dictionary objectForKey:key] == nil)
			{
				[self.orderedKeys addObject:key];
				[self.dictionary setObject:item forKey:key];
			}
		}

		self.combobox.usesDataSource = YES;
		if (self.combobox.dataSource == nil)
		{
			self.combobox.dataSource = self;
		}

		[self setFilter:self.currentFilter];
	}
}

- (void)reload
{
	NSAssert([NSThread isMainThread], @"Rendering stuff should happen on main thread");

	[self.combobox reloadData];
}

- (NSUInteger)count
{
	NSUInteger result = 0;

	@synchronized(self)
	{
		result = [self.filteredOrderedKeys count];
	}
	return result;
}

- (NSString *)keyAtIndex:(NSInteger)row
{
	NSString *key = nil;

	@synchronized(self)
	{
		key = [self.filteredOrderedKeys objectAtIndex:row];
	}
	return key;
}

- (NSUInteger)indexOfKey:(NSString *)key
{
	NSUInteger index = 0;

	@synchronized(self)
	{
		return [self.filteredOrderedKeys indexOfObject:key];
	}
	return index;
}

- (void)setFilter:(NSString *)filter
{
	self.textLength = 0;
	@synchronized(self)
	{
		self.currentFilter = filter;
		if (filter == nil || filter.length == 0)
		{
			self.filteredOrderedKeys = [NSMutableArray arrayWithArray:self.orderedKeys];
			[self reload];
			return;
		}
		NSMutableArray *filtered = [[NSMutableArray alloc] init];
		for (int i = 0; i < self.orderedKeys.count; i++)
		{
			NSString *key = self.orderedKeys[i];
			if ([key rangeOfString:filter options:NSCaseInsensitiveSearch].location != NSNotFound)
			{
				if ([key length] > self.textLength)
				{
					self.textLength = [key length];
				}
				[filtered addObject:key];
			}
		}
		self.filteredOrderedKeys = filtered;
	}
	[self reload];
}

- (NSString *)comboBox:(NSComboBox *)comboBox completedString:(NSString *)partialString
{
	return [self completedString:partialString];
}

- (NSInteger)numberOfItemsInComboBox:(NSComboBox *)aComboBox
{
	return [self count];
}

- (id)comboBox:(NSComboBox *)aComboBox objectValueForItemAtIndex:(NSInteger)row
{
	return [self keyAtIndex:row];
}

- (NSUInteger)comboBox:(NSComboBox *)aComboBox indexOfItemWithStringValue:(NSString *)aString
{
	return [self indexOfKey:aString];
}

@end
